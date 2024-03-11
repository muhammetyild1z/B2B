using AutoMapper;
using B2B.API.Dtos.ProductPriceDtos;
using B2B.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductPriceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductPriceService _productPriceService;

        public ProductPriceController(IMapper mapper, IProductPriceService productPriceService)
        {
            _mapper = mapper;
            _productPriceService = productPriceService;
        }

        [HttpGet("GetAllProductPrice")]
        public IActionResult GetAllProductPrice()
        {
            var productPrice= _productPriceService.TGetIncludePriceList();
            return Ok(_mapper.Map<List<ResultProductPriceDto>>(productPrice));
        }
    }
}
