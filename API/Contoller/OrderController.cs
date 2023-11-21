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
    public class OrderController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var order = await _unitOfWork.Orders
                                        .GetAllAsync();

            return _mapper.Map<List<OrderDto>>(order);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            return _mapper.Map<OrderDto>(order);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveAsync();
            if (order == null)
            {
                return BadRequest();
            }
            orderDto.Id = order.Id;
            return CreatedAtAction(nameof(Post), new { id = orderDto.Id }, orderDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Orders.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var order = _mapper.Map<Order>(orderDto);
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveAsync();
            return orderDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpGet("/GetAllStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllStatus()
        {
            var order = await _unitOfWork.Orders.GetAllAsync();

            return _mapper.Map<List<OrderDto>>(order);
        }
        
        [HttpGet("/GetOrderYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderByStatusYear(string status,int orderr)
        {
            var order = await _unitOfWork.Orders.GetOrderByStatusYear(status,orderr);

            return _mapper.Map<List<OrderDto>>(order);
        }
    }
}