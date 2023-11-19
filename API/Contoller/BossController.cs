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
    public class BossController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BossController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BossDto>>> Get()
        {
            var boss = await _unitOfWork.Bosses
                                        .GetAllAsync();

            return _mapper.Map<List<BossDto>>(boss);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BossDto>> Get(int id)
        {
            var boss = await _unitOfWork.Bosses.GetByIdAsync(id);
            if (boss == null)
                return NotFound();

            return _mapper.Map<BossDto>(boss);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Boss>> Post(BossDto bossDto)
        {
            var boss = _mapper.Map<Boss>(bossDto);
            _unitOfWork.Bosses.Add(boss);
            await _unitOfWork.SaveAsync();
            if (boss == null)
            {
                return BadRequest();
            }
            bossDto.Id = boss.Id;
            return CreatedAtAction(nameof(Post), new { id = bossDto.Id }, bossDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BossDto>> Put(int id, [FromBody] BossDto bossDto)
        {
            if (bossDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Bosses.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var boss = _mapper.Map<Boss>(bossDto);
            _unitOfWork.Bosses.Update(boss);
            await _unitOfWork.SaveAsync();
            return bossDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var boss = await _unitOfWork.Bosses.GetByIdAsync(id);
            if (boss == null)
                return NotFound();

            _unitOfWork.Bosses.Delete(boss);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}