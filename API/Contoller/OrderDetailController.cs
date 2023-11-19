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
    public class OrderDetailController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> Get()
        {
            var orderDetail = await _unitOfWork.OrderDetails
                                        .GetAllAsync();

            return _mapper.Map<List<OrderDetailDto>>(orderDetail);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailDto>> Get(int id)
        {
            var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if (orderDetail == null)
                return NotFound();

            return _mapper.Map<OrderDetailDto>(orderDetail);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetail>> Post(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            _unitOfWork.OrderDetails.Add(orderDetail);
            await _unitOfWork.SaveAsync();
            if (orderDetail == null)
            {
                return BadRequest();
            }
            orderDetailDto.Id = orderDetail.Id;
            return CreatedAtAction(nameof(Post), new { id = orderDetailDto.Id }, orderDetailDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetailDto>> Put(int id, [FromBody] OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            _unitOfWork.OrderDetails.Update(orderDetail);
            await _unitOfWork.SaveAsync();
            return orderDetailDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if (orderDetail == null)
                return NotFound();

            _unitOfWork.OrderDetails.Delete(orderDetail);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}