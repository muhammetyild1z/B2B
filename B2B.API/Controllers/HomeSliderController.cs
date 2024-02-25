using AutoMapper;
using B2B.API.Dtos.HomeSliderDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Privacy;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HomeSliderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHomeSliderService _homeSliderService;

        public HomeSliderController(IMapper mapper, IHomeSliderService homeSliderService)
        {
            _mapper = mapper;
            _homeSliderService = homeSliderService;
        }

        [HttpGet("AllGetHomeSlider")]
        public async Task<IActionResult> AllGetHomeSlider()
        {
            var homeSliders = _homeSliderService.TGetListAsync();
            return Ok(_mapper.Map<List<ResultHomeSliderDto>>(homeSliders));
        }

        [HttpPost("CreateHomeSlider")]
        public async Task<IActionResult> CreateHomeSlider(CreateHomeSliderDto createHomeSliderDto)
        {

            if (createHomeSliderDto != null)
            {
                var result = _homeSliderService.TInsertAsync(_mapper.Map<HomeSlider>(createHomeSliderDto));
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

        [HttpPut("UpdateHomeSlider")]
        public async Task<IActionResult> UpdateHomeSlider(UpdateHomeSliderDto updateHomeSliderDto)
        {
            if (updateHomeSliderDto != null)
            {
                var unchangedHomeSlider = _homeSliderService.TGetByID(updateHomeSliderDto.SliderID);
                if (unchangedHomeSlider != null)
                {
                    var result = _homeSliderService.TUpdateAsync(_mapper.Map<HomeSlider>(updateHomeSliderDto), unchangedHomeSlider);
                    if (result.IsCompleted)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NoContent();
                    }
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

        [HttpDelete("DeleteHomeSlider/{id}")]
        public IActionResult DeleteHomeSlider(int id)
        {
            if (id != 0)
            {
                var removedHomeSlider = _homeSliderService.TGetByID(id);
                if (removedHomeSlider != null)
                {
                    _homeSliderService.TDelete(removedHomeSlider);
                    return Ok();
                }
                else
                {
                    BadRequest();
                }
            }


            return NotFound();

        }
    }
}
