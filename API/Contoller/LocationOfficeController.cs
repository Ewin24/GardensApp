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
    public class LocationOfficeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationOfficeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LocationOfficeDto>>> Get()
        {
            var locationOffice = await _unitOfWork.LocationOffices
                                        .GetAllAsync();

            return _mapper.Map<List<LocationOfficeDto>>(locationOffice);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationOfficeDto>> Get(int id)
        {
            var locationOffice = await _unitOfWork.LocationOffices.GetByIdAsync(id);
            if (locationOffice == null)
                return NotFound();

            return _mapper.Map<LocationOfficeDto>(locationOffice);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationOffice>> Post(LocationOfficeDto locationOfficeDto)
        {
            var locationOffice = _mapper.Map<LocationOffice>(locationOfficeDto);
            _unitOfWork.LocationOffices.Add(locationOffice);
            await _unitOfWork.SaveAsync();
            if (locationOffice == null)
            {
                return BadRequest();
            }
            locationOfficeDto.Id = locationOffice.Id;
            return CreatedAtAction(nameof(Post), new { id = locationOfficeDto.Id }, locationOfficeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationOfficeDto>> Put(int id, [FromBody] LocationOfficeDto locationOfficeDto)
        {
            if (locationOfficeDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.LocationOffices.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var locationOffice = _mapper.Map<LocationOffice>(locationOfficeDto);
            _unitOfWork.LocationOffices.Update(locationOffice);
            await _unitOfWork.SaveAsync();
            return locationOfficeDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var locationOffice = await _unitOfWork.LocationOffices.GetByIdAsync(id);
            if (locationOffice == null)
                return NotFound();

            _unitOfWork.LocationOffices.Delete(locationOffice);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}