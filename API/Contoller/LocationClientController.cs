using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Contoller
{
    public class LocationClientController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LocationClientDto>>> Get()
        {
            var locationClient = await _unitOfWork.LocationClients
                                        .GetAllAsync();

            return _mapper.Map<List<LocationClientDto>>(locationClient);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationClientDto>> Get(int id)
        {
            var locationClient = await _unitOfWork.LocationClients.GetByIdAsync(id);
            if (locationClient == null)
                return NotFound();

            return _mapper.Map<LocationClientDto>(locationClient);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationClient>> Post(LocationClientDto locationClientDto)
        {
            var locationClient = _mapper.Map<LocationClient>(locationClientDto);
            _unitOfWork.LocationClients.Add(locationClient);
            await _unitOfWork.SaveAsync();
            if (locationClient == null)
            {
                return BadRequest();
            }
            locationClientDto.Id = locationClient.Id;
            return CreatedAtAction(nameof(Post), new { id = locationClientDto.Id }, locationClientDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationClientDto>> Put(int id, [FromBody] LocationClientDto locationClientDto)
        {
            if (locationClientDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.LocationClients.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var locationClient = _mapper.Map<LocationClient>(locationClientDto);
            _unitOfWork.LocationClients.Update(locationClient);
            await _unitOfWork.SaveAsync();
            return locationClientDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var locationClient = await _unitOfWork.LocationClients.GetByIdAsync(id);
            if (locationClient == null)
                return NotFound();

            _unitOfWork.LocationClients.Delete(locationClient);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}