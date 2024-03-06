using AutoMapper;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductdimensionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductdimensionsService _dimensions;
     

        public ProductdimensionsController(IMapper mapper, IProductdimensionsService datasetsService)
        {
            _mapper = mapper;
            _dimensions = datasetsService;
        }

        [HttpGet("GetProductWithDimensions/{productID}")]
        public IActionResult GetProductWithDimensions(int productID)
        {
            if (productID != 0)
            {
                var dimensions = _dimensions.TGetProductDimensionsInclude().Where(x=>x.ProductID==productID);
                return Ok(dimensions);
            }
            return NotFound();
        }
        [HttpGet("GetByIdDimension/{ProductdimensionsID}")]
        public IActionResult GetByIdDimension(int ProductdimensionsID)
        {
            if (ProductdimensionsID != 0)
            {
                var dimensions = _dimensions.TGetList().Where(x=>x.ProductdimensionsID== ProductdimensionsID).Select(x=>x.ProductPrice).FirstOrDefault();
                return Ok(dimensions);
            }
            return NotFound();
        }

    }
}
