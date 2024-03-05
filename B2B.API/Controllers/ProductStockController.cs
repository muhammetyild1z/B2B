using AutoMapper;
using B2B.API.Dtos.StockDtos;
using B2B.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductStockController : Controller
    {
        private readonly IProductStockService _productStockService;
        private readonly IMapper _mapper;

        public ProductStockController(IProductStockService productStockService, IMapper mapper)
        {
            _productStockService = productStockService;
            _mapper = mapper;
        }
        [HttpGet("GetProductStock/{productID}")]
        public IActionResult GetProductStock(int productID)
        {
            if (productID!=0)
            {
                var productStock = _productStockService.TGetList().Where(x => x.ProductID == productID).Select(x=>x.Stock).FirstOrDefault();
                ProductStockDto stock = new ProductStockDto()
                {
                    ProductStockCount = productStock
                };
                return Ok(stock);
            }
          
            return NotFound();
        }
    }
}
