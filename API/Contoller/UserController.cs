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

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserDto request)
        {
            try
            {
                var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.email);

                if (existingUser != null)
                {
                    BadRequest("El usuario ya está registrado");
                }

                var newUser = new User
                {
                    email = request.email,
                    Password = request.Password
                };

                this._unitOfWork.Users.Add(newUser);
                await this._unitOfWork.SaveAsync();

                return Ok(); // Devuelve true si el usuario se registra correctamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, false); // Envía falso en caso de error
            }
        }


        [HttpPost("Login")]
        public async Task<bool> Login(UserDto request)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(request.email);

                if (user == null)
                {
                    return false;
                }
                bool passwordMatches = (request.Password == user.Password);

                return passwordMatches;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // [HttpPost("register")]
        // public ActionResult<User> Register(UserDto request)
        // {
        //     string passwordHash
        //         = BCrypt.Net.BCrypt.HashPassword(request.Password);

        //     user.Username = request.Username;
        //     user.PasswordHash = passwordHash;

        //     return Ok(user);
        // }

        // [HttpPost("login")]
        // public ActionResult<User> Login(UserDto request)
        // {
        //     if (user.Username != request.Username)
        //     {
        //         return BadRequest("User not found.");
        //     }

        //     if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        //     {
        //         return BadRequest("Wrong password.");
        //     }

        //     string token = CreateToken(user);

        //     return Ok(token);
        // }

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