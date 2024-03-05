using AutoMapper;
using B2B.API.Dtos.ProductColorDtos;
using B2B.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductColorController : Controller
    {
        private readonly IProductColorService _productColorService;
        private readonly IMapper _mapper;

        public ProductColorController(IProductColorService productColorService, IMapper mapper)
        {
            _productColorService = productColorService;
            _mapper = mapper;
        }

        [HttpGet("GetProductColor/{productID}")]
        public IActionResult GetProduct(int productID)
        {
            if (productID != 0)
            {
                var colors= _productColorService.TGetProductColorInclude().Where(x=>x.productID == productID).ToList();
                return Ok( _mapper.Map<List<ResultProductColorDto>>(colors));
            }
            return NotFound();
        }
    }
}
