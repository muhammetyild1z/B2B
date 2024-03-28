using AutoMapper;
using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ProductCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _categoryService;

        public ProductCategoryController(IMapper mapper, IProductCategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("AllGetProductCategory")]
        public IActionResult AllGetProductCategory()
        {
            var category = _categoryService.TGetAllCategoriesInclude();
            return Ok(_mapper.Map<List<ProductCategory>>(category));
        }

        
        [HttpGet("GetByIdProductCategory/{producID}")]
        public IActionResult GetByIdProductCategory(int producID)
        {
            var category = _categoryService.TGetAllCategoriesInclude().Where(x => x.ProductID == producID);
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(category));
        }



        [HttpPut("UpdateProductCategory")]
        public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryDto updateProductCategoryDto)
        {
            if (updateProductCategoryDto != null)
            {
                var unchangedCategory = _categoryService.TGetByID(updateProductCategoryDto.ProductCategoryID);
                if (unchangedCategory != null)
                {
                    var result = _categoryService.TUpdateAsync(_mapper.Map<ProductCategory>(updateProductCategoryDto), unchangedCategory);
                    if (result.IsCompleted)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("CreateProductCategory")]
        public async Task<IActionResult> CreateProductCategory(CreateProductCategoryDto createProductCategoryDto)
        {
            if (createProductCategoryDto.ProductID != 0)
            {


                var result = _categoryService.TInsertAsync(_mapper.Map<ProductCategory>(createProductCategoryDto));
                if (result.IsCompletedSuccessfully)
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteProductCategory/{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            if (id != 0)
            {
                var deleteCategory = _categoryService.TGetProductCategoryByID(id);
                _categoryService.TDelete(deleteCategory);
                return Ok();
            }
            else return NotFound();
        }



        [HttpGet("AllGetIncludeProductCategory")]
        public IActionResult AllGetIncludeProductCategory()
        {
            var category = _categoryService.TAllGetIncludeProductCategory();
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(category));
        }

        [HttpGet("GetIncludeProductCategory/{categoryId}")]
        public IActionResult GetIncludeProductCategory(int categoryId)
        {
            var categoryProduct = _categoryService.TAllGetIncludeProductCategory().Where(x=>x.CategoryID==categoryId);
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(categoryProduct));
        }

        [HttpGet("GetIncludeProductSubCategory/{subcategory}")]
        public IActionResult GetIncludeProductSubCategory(int subcategory)
        {
            var categoryProduct = _categoryService.TAllGetIncludeProductCategory().Where(x => x.ParentSubCategoryID == subcategory);
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(categoryProduct));
        }
    }
}

