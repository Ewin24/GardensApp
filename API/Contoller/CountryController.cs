using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CountryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            var country = await _unitOfWork.Countries
                                        .GetAllAsync();

            return _mapper.Map<List<CountryDto>>(country);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Get(int id)
        {
            var country = await _unitOfWork.Countries.GetByIdAsync(id);
            if (country == null)
                return NotFound();

            return _mapper.Map<CountryDto>(country);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Country>> Post(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            _unitOfWork.Countries.Add(country);
            await _unitOfWork.SaveAsync();
            if (country == null)
            {
                return BadRequest();
            }
            countryDto.Id = country.Id;
            return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
        {
            if (countryDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Countries.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var country = _mapper.Map<Country>(countryDto);
            _unitOfWork.Countries.Update(country);
            await _unitOfWork.SaveAsync();
            return countryDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _unitOfWork.Countries.GetByIdAsync(id);
            if (country == null)
                return NotFound();

            _unitOfWork.Countries.Delete(country);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}