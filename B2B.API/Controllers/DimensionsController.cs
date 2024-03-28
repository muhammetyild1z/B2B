using AutoMapper;
using B2B.API.Dtos.DimensionsDto;
using B2B.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DimensionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeService _productSize;
        private readonly IDimensionsService _dimensionsService;

        public DimensionsController(IMapper mapper, IProductSizeService productSize, IDimensionsService dimensionsService)
        {
            _mapper = mapper;
            _productSize = productSize;
            _dimensionsService = dimensionsService;
        }

        [HttpGet("GetByIDProductSize/{productID}")]
        public IActionResult GetByIDProductSize(int productID)
        {
            var productSize = _productSize.TGetList().Where(x => x.ProductID == productID).Select(x => x.DimensionsID).ToList();
            var productDimensionList = _dimensionsService.TGetList()
     .Where(dim => productSize.Contains(dim.DimensionsID))
     .ToList();

            return Ok(_mapper.Map<List<ResultDimensionsDto>>(productDimensionList));
        }

        [HttpGet("GetAllDimensions")]
        public IActionResult GetAllDimensions()
        {
            var dimensionsList = _dimensionsService.TGetList();
            var mapperDimensions = _mapper.Map<List<ResultDimensionsDto>>(dimensionsList);
            return Ok(mapperDimensions);
        }



    }
}
