using AutoMapper;
using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ProductCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryService _productCategory;

        public CategoryController(IMapper mapper, ICategoryService categoryService, IProductCategoryService productCategory)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productCategory = productCategory;
        }

        [HttpGet("AllGetCategory")]
        [Authorize]
        public IActionResult AllGetCategory()
        {
            var category = _categoryService.TGetList();
            return Ok(_mapper.Map<List<Category>>(category));
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto != null)
            {
                var unchangedCategory = _categoryService.TGetByID(updateCategoryDto.CategoryID);
                if (unchangedCategory != null)
                {
                    var result = _categoryService.TUpdateAsync(_mapper.Map<Category>(updateCategoryDto), unchangedCategory);
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

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto.Name != null)
            {
                createCategoryDto.CreateDate = DateTime.Now;
                createCategoryDto.Status = false;
                var result = _categoryService.TInsertAsync(_mapper.Map<Category>(createCategoryDto));
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

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id != 0)
            {
                var deleteCategory = _categoryService.TGetCategoryByID(id);
                _categoryService.TDelete(deleteCategory);
                return Ok();
            }
            else return NotFound();
        }

        [HttpGet("HomeCategory")]
        public async Task<IActionResult> HomeCategory()
        {
            var getGategory = _categoryService.TGetList().Take(4);
            return Ok(_mapper.Map<List<ResultCategoryDto>>(getGategory));

        }

        [HttpGet("ProductPropCategory")]
        public async Task<IActionResult> ProductPropCategory(int id)
        {
            var productPropCategory = _productCategory.TGetList().Where(x=>x.ProductID==id);
            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(productPropCategory));

        }


    }
}
