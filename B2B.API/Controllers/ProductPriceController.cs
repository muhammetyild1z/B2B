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
        private readonly IProductColorService _productColor;
        private readonly IStockService _stockService;

        public ProductPriceController(IMapper mapper, IProductPriceService productPriceService, IProductColorService productColor, IStockService stockService)
        {
            _mapper = mapper;
            _productPriceService = productPriceService;
            _productColor = productColor;
            _stockService = stockService;
        }

        [HttpGet("GetAllProductPrice")]
        public IActionResult GetAllProductPrice()
        {
            var productPrice = _productPriceService.TGetIncludePriceList();
            return Ok(_mapper.Map<List<ResultProductPriceDto>>(productPrice));
        }


        [HttpGet("GetByIdProductPrice/{priceID}")]
        public IActionResult GetByIdProductPrice(int priceID)
        {
            var productPrice = _productPriceService.TGetByIdIncludePrice(priceID);
            return Ok(_mapper.Map<ResultProductPriceDto>(productPrice));
        }


        [HttpPost("GetProductDimension")]
        public IActionResult GetProductDimension(CreateProductPriceDto dto)
        {
            CreateProductPriceDto a = new CreateProductPriceDto();
          var  productPrice = _productPriceService.TGetList().FirstOrDefault(x => x.DimensionsID == dto.DimensionsID && x.ColorID == dto.ColorID && x.ProductID == dto.ProductID);
           
            a = _mapper.Map<CreateProductPriceDto>(productPrice);
            a.StockQuantity = _stockService.TGetList().Find(x => x.StockID == productPrice.StockID).Quantity;

            return Ok(a);
        }

        [HttpGet("GetProductColor/{productID}")]
        public IActionResult GetProductColor(int productID)
        {
            var productPrice = _productColor.TGetColorIncludeProducts()
                .Where(x => x.ProductID == productID).ToList();
            return Ok(productPrice);
        }






    }
}
