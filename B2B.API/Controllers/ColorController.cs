using AutoMapper;
using B2B.API.Dtos.ColorDtos;
using B2B.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorController(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }
        [HttpGet("GetAllColor")]
        public IActionResult GetAllColor()
        {
            var colorList = _colorService.TGetList();
            var colorMap = _mapper.Map<List<ResultColorDto>>(colorList);
            return Ok(colorMap);
        }
    }
}
