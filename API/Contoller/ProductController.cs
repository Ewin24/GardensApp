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
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var product = await _unitOfWork.Products
                                        .GetAllAsync();

            return _mapper.Map<List<ProductDto>>(product);
        }

        [HttpGet("GetByGamaStock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByGamaStock([FromQuery] string productLine, [FromQuery] int stockQuantity)
        {
            var products = await _unitOfWork.Products.GetByGamaStock(productLine, stockQuantity);

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpGet("GetNeverInOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetNeverInOrder()
        {
            var products = await _unitOfWork.Products.GetNeverInOrder();

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpGet("GetNeverInOrderspecified")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetNeverInOrderspecified()
        {
            var products = await _unitOfWork.Products.GetNeverInOrderspecified();

            return Ok(products);
        }

        [HttpGet("GetByDifferentProdQuantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> GetByDifferentProdQuantity()
        {
            var result = await _unitOfWork.Orders.GetByDifferentProdQuantity();

            return Ok(result);
        }

        [HttpGet("GetByHigherSalesPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> GetByHigherSalesPrice()
        {
            var product = await _unitOfWork.Products.GetByHigherSalesPrice();

            if (product == null)
            {
                return NotFound(); // Otra opción podría ser retornar un objeto con información indicando que no se encontró ningún producto.
            }

            return _mapper.Map<ProductDto>(product);
        }

        [HttpGet("GetByNotInOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByNotInOrder()
        {
            var products = await _unitOfWork.Products.GetByNotInOrder();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return _mapper.Map<ProductDto>(product);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
            if (product == null)
            {
                return BadRequest();
            }
            productDto.Id = product.Id;
            return CreatedAtAction(nameof(Post), new { id = productDto.Id }, productDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return NotFound();

            var productoBd = await _unitOfWork.Products.GetByIdAsync(id);
            if (productoBd == null)
                return NotFound();

            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
            return productDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}