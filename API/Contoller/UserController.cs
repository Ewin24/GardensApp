using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dto;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;

namespace API.Contoller
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<object>> Register(UserDto request)
        {
            try
            {
                User user = new User();
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                user.email = request.email;
                user.Password = passwordHash;

                // Asigna el resultado del mapeo a la entidad User
                _mapper.Map(request, user);

                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveAsync();

                return Ok(new { Message = "Registration successful" });
            }
            catch (DbUpdateException ex)
            {
                // Imprimir información detallada sobre la excepción
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                // Puedes también imprimir la traza de la excepción para obtener más detalles
                Console.WriteLine($"Exception Stack Trace: {ex.StackTrace}");

                // Manejar la excepción según tus necesidades
                return StatusCode(500, "Internal Server Error");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones según tus necesidades
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong password.");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.email),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }

}