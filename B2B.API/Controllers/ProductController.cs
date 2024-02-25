﻿using AutoMapper;
using B2B.API.Dtos.ProductDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("AllGetProduct")]
        public async Task<IActionResult> AllGetProduct()
        {
            var products= _productService.TGetListAsync();
            return Ok(_mapper.Map<List<Product>>(products));
        }

        [HttpPost("CreateProduct")]
        public async Task <IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto!=null)
            {
                var result= _productService.TInsertAsync(_mapper.Map<Product>(createProductDto));
                if (result.IsCompleted)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id!=0)
            {
                var removedProduct = _productService.TGetByID(id);
                if (removedProduct!=null)
                {
                    _productService.TDelete(removedProduct);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (updateProductDto!=null)
            {
                var unchangedProduct= _productService.TGetByID(updateProductDto.Product_ID);
                if (unchangedProduct!=null)
                {
                    var result = _productService.TUpdateAsync(_mapper.Map<Product>(updateProductDto),unchangedProduct);
                    if (result.IsCompleted)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return NotFound();
        }
    }
}
