using AutoMapper;
using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ProductCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Collections.Generic;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _categoryService;

        public AllProductController(IMapper mapper, IProductCategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost("FilterCategory")]
        public IActionResult FilterCategory([FromBody] FilterDto filter)
        {
            List<ProductCategory> products = new List<ProductCategory>();

            for (int i = 0; i < filter.CategoryId.Count; i++)
            {
                 products = _categoryService.TAllGetIncludeProductCategory()
                                        .Where(x => x.ParentSubCategoryID == filter.CategoryId[i])
                                        .ToList();

                
            }           
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(products));
        }
    }
}
