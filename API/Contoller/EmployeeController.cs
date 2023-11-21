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
    public class EmployeeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            var employee = await _unitOfWork.Employee
                                        .GetAllAsync();

            return _mapper.Map<List<EmployeeDto>>(employee);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return _mapper.Map<EmployeeDto>(employee);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Post(EmployeeDto cityDto)
        {
            var employee = _mapper.Map<Employee>(cityDto);
            _unitOfWork.Employee.Add(employee);
            await _unitOfWork.SaveAsync();
            if (employee == null)
            {
                return BadRequest();
            }
            cityDto.Id = employee.Id;
            return CreatedAtAction(nameof(Post), new { id = cityDto.Id }, cityDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto cityDto)
        {
            if (cityDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Employee.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var employee = _mapper.Map<Employee>(cityDto);
            _unitOfWork.Employee.Update(employee);
            await _unitOfWork.SaveAsync();
            return cityDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            _unitOfWork.Employee.Delete(employee);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
         [HttpGet("/Ge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeesQuantity()
        {
            var employee = await _unitOfWork.Employee
                                        .GetAllAsync();

            return _mapper.Map<List<EmployeeDto>>(employee);
        }
    }
}