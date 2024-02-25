using AutoMapper;
using B2B.API.Dtos.ParentSubCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ParentSubCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IParentSubCategoryService _parentSubCategoryService;

        public ParentSubCategoryController(IMapper mapper, IParentSubCategoryService parentSubCategoryService)
        {
            _mapper = mapper;
            _parentSubCategoryService = parentSubCategoryService;
        }

        [HttpGet("AllGetParentSubCategory")]
        public IActionResult AllGetParentSubCategory()
        {
            var parentSubCategoryies = _parentSubCategoryService.TGetListAsync();
            return View(_mapper.Map<List<ParentSubCategory>>(parentSubCategoryies));
        }
        [HttpPost("CreateParentSubCategory")]
        public async Task<IActionResult> CreateParentSubCategory(CreateParentSubCategoryDto createParentSubCategoryDto)
        {
            if (createParentSubCategoryDto != null)
            {
                var result = _parentSubCategoryService.TInsertAsync(_mapper.Map<ParentSubCategory>(createParentSubCategoryDto));
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

        [HttpPut("UpdateParentSubCategory")]
        public async Task<IActionResult> UpdateParentSubCategory(UpdateParentSubCategoryDto updateParentSubCategoryDto)
        {
            if (updateParentSubCategoryDto != null)
            {
                var unchangedParentSubCategory = _parentSubCategoryService.TGetByID(updateParentSubCategoryDto.ParentSubCategoryID);
                if (unchangedParentSubCategory != null)
                {
                    var result = _parentSubCategoryService.TUpdateAsync(unchangedParentSubCategory, _mapper.Map<ParentSubCategory>(updateParentSubCategoryDto));
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
            return NotFound();
        }

        [HttpDelete("DeleteParentSubCategory/{id}")]
        public async Task<IActionResult> DeleteParentSubCategory(int id)
        {
            if (id != 0)
            {
                var removedParentSubCategory = _parentSubCategoryService.TGetByID(id);
                if (removedParentSubCategory != null)
                {
                    _parentSubCategoryService.TDelete(removedParentSubCategory);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

    }
}
