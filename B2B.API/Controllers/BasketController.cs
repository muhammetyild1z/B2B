using AutoMapper;
using B2B.API.Dtos.BasketDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("AllGetBasket")]
        public IActionResult AllGetBasket()
        {
            var basket = _basketService.TGetList();
            return Ok(_mapper.Map<List<Basket>>(basket));
        } 
        [HttpGet("UserAllBasket/{id}")]
        public IActionResult UserAllBasket(string id)
        {
            var basketList = _basketService.TGetIncludeAllUserBasket().Where(x=>x.UserID==id).ToList();
            return Ok(_mapper.Map<List<ResultBasketDto>>(basketList));
        }

        [HttpPost("DeleteBasket/{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            if (id != 0)
            {
                var basketRemove = _basketService.TGetBasketByID(id);
                if (basketRemove != null)
                {
                    _basketService.TDelete(basketRemove);
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

        [HttpPut("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket(UpdateBasketDto updateBasketDto)
        {
            if (updateBasketDto != null)
            {
                var unchangedBasket = _basketService.TGetByID(updateBasketDto.BasketID);
                var result = _basketService.TUpdateAsync(_mapper.Map<Basket>(updateBasketDto), unchangedBasket);
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

        [HttpPost("CreateBasket")]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketDto dto)
        {
       
            dto.Status = true;
            dto.CreateDate = DateTime.Now;
            var basket = _mapper.Map<Basket>(dto);
            var basketCheck = _basketService.TGetIncludeAllUserBasket().Find(x=>x.UserID== basket.UserID && x.PriceID==basket.PriceID );
            if (basketCheck==null)
            {
                var result = _basketService.TInsertAsync(basket);
                if (result.IsCompleted)
                {
                    return Ok();
                }
            }
            else
            {
                basketCheck.Count += dto.Count;
                var result = _basketService.TUpdateAsync(basketCheck, basketCheck);
                if (result.IsCompleted)
                {
                    return Ok();
                }
               

            }
        
            return NotFound();

        }
    }
}
