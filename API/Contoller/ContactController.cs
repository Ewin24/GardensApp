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
    public class ContactController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactDto>>> Get()
        {
            var contact = await _unitOfWork.Contacts
                                        .GetAllAsync();

            return _mapper.Map<List<ContactDto>>(contact);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return _mapper.Map<ContactDto>(contact);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contact>> Post(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _unitOfWork.Contacts.Add(contact);
            await _unitOfWork.SaveAsync();
            if (contact == null)
            {
                return BadRequest();
            }
            contactDto.Id = contact.Id;
            return CreatedAtAction(nameof(Post), new { id = contactDto.Id }, contactDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactDto>> Put(int id, [FromBody] ContactDto contactDto)
        {
            if (contactDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var contact = _mapper.Map<Contact>(contactDto);
            _unitOfWork.Contacts.Update(contact);
            await _unitOfWork.SaveAsync();
            return contactDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            _unitOfWork.Contacts.Delete(contact);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}