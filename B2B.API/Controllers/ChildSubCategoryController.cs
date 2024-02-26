using AutoMapper;
using B2B.API.Dtos.ChildSubCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ChildSubCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChildSubCategoryService _childSubCategoryService;

        public ChildSubCategoryController(IMapper mapper, IChildSubCategoryService childSubCategoryService)
        {
            _mapper = mapper;
            _childSubCategoryService = childSubCategoryService;
        }

        [HttpGet("AllGetChildSubCategory")]
        public IActionResult AllGetChildSubCategory()
        {
            var childCategory = _childSubCategoryService.TGetList();
            return Ok(_mapper.Map<List<ResultChildSubCategoryDto>>(childCategory));
        }

        [HttpPost("CreateChildSubCategory")]
        public async Task< IActionResult> CreateChildSubCategory(CreateChildSubCategoryDto createChildSubCategoryDto)
        {
            if (createChildSubCategoryDto.Name!=null)
            {
                createChildSubCategoryDto.CreateDate = DateTime.Now;
                createChildSubCategoryDto.Status = false;
                var result = _childSubCategoryService.TInsertAsync(_mapper.Map<ChildSubCategory>(createChildSubCategoryDto));
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

        [HttpPut("UpdateChildSubCategory")]
        public async Task<IActionResult> UpdateChildSubCategory(UpdateChildSubCategoryDto updateChildSubCategoryDto)
        {
            if (updateChildSubCategoryDto!=null)
            {
                var unchangedChildSubCategory = _childSubCategoryService.TGetByID(updateChildSubCategoryDto.ChildSubCategoryID);
                var result = _childSubCategoryService.TUpdateAsync(_mapper.Map<ChildSubCategory>(updateChildSubCategoryDto), unchangedChildSubCategory);
                if (result.IsCompleted)
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteChildSubCategory/{id}")]
        public async Task<IActionResult> DeleteChildSubCategory(int id)
        {
            if (id!=0)
            {
                var removedChildCategory= _childSubCategoryService.TGetChildSubByID(id);
                if (removedChildCategory!=null)
                {
                    _childSubCategoryService.TDelete(removedChildCategory);
                    return Ok();
                }
                return BadRequest();
               
            }
            else
            {
                return NotFound();
            }
        }

    }
}
