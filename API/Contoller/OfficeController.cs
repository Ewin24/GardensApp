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
    public class OfficeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfficeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> Get()
        {
            var office = await _unitOfWork.Offices
                                        .GetAllAsync();

            return _mapper.Map<List<OfficeDto>>(office);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Get(int id)
        {
            var office = await _unitOfWork.Offices.GetByIdAsync(id);
            if (office == null)
                return NotFound();

            return _mapper.Map<OfficeDto>(office);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Office>> Post(OfficeDto officeDto)
        {
            var office = _mapper.Map<Office>(officeDto);
            _unitOfWork.Offices.Add(office);
            await _unitOfWork.SaveAsync();
            if (office == null)
            {
                return BadRequest();
            }
            officeDto.Id = office.Id;
            return CreatedAtAction(nameof(Post), new { id = officeDto.Id }, officeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OfficeDto>> Put(int id, [FromBody] OfficeDto officeDto)
        {
            if (officeDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Offices.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var office = _mapper.Map<Office>(officeDto);
            _unitOfWork.Offices.Update(office);
            await _unitOfWork.SaveAsync();
            return officeDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var office = await _unitOfWork.Offices.GetByIdAsync(id);
            if (office == null)
                return NotFound();

            _unitOfWork.Offices.Delete(office);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

      /*   [HttpGet("{/OficinasCiudad}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<>>> OficinaCiudad()
        {
            var office = await _unitOfWork.Offices
                                        .GetAllAsync();

            return _mapper.Map<List<OfficeDto>>(office);
        } */
    }
}