using AutoMapper;
using B2B.API.Dtos.BasketDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
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
        public async Task<IActionResult> AllGetBasket()
        {
            var basket = await _basketService.TGetListAsync();
            return Ok(basket);
        }

        [HttpDelete("DeleteBasket/{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            if (id != 0)
            {
                var basketRemove = _basketService.TGetByID(id);
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
                var result =  _basketService.TUpdateAsync(_mapper.Map<Basket>(updateBasketDto),unchangedBasket);
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
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            if (createBasketDto!=null)
            {
              var result=   _basketService.TInsertAsync(_mapper.Map<Basket>(createBasketDto));
                if (result.IsCompleted)
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
