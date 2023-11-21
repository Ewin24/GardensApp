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
    public class PaymentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> Get()
        {
            var payment = await _unitOfWork.Payment
                                        .GetAllAsync();

            return _mapper.Map<List<PaymentDto>>(payment);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Get(int id)
        {
            var payment = await _unitOfWork.Payment.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            return _mapper.Map<PaymentDto>(payment);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Payment>> Post(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            _unitOfWork.Payment.Add(payment);
            await _unitOfWork.SaveAsync();
            if (payment == null)
            {
                return BadRequest();
            }
            paymentDto.Id = payment.Id;
            return CreatedAtAction(nameof(Post), new { id = paymentDto.Id }, paymentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentDto>> Put(int id, [FromBody] PaymentDto paymentDto)
        {
            if (paymentDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Payment.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var payment = _mapper.Map<Payment>(paymentDto);
            _unitOfWork.Payment.Update(payment);
            await _unitOfWork.SaveAsync();
            return paymentDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _unitOfWork.Payment.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            _unitOfWork.Payment.Delete(payment);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }


        //GetPaymentMethod
        [HttpGet("GetByPaymentMethodYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetByPaymentMethodYear(string paymentMethod, int year)
        {
            var payment = await _unitOfWork.Payment.GetByPaymentMethodYear();

            return _mapper.Map<List<PaymentDto>>(payment);
        }

        //GetPaymentMethods
        [HttpGet("GetPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetPayMethods()
        {
            var methods = await _unitOfWork.Payment.GetPayMethods();

            return Ok(methods);
        }

        //GetPaymentYear
        [HttpGet("GetPaymentAverageIn2009")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> GetOrderPaymentAverangeIn2009(string paymentMethod, int year)
        {
            var payment = await _unitOfWork.Payment.GetOrderPaymentAverangeIn2009();

            return _mapper.Map<List<PaymentDto>>(payment);
        }
    }
}