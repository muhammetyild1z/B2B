using AutoMapper;
using B2B.API.Dtos.ProductPriceDtos;
using B2B.API.Dtos.UserFavoriDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFavoriController : Controller
    {
        private readonly IUserFavoriService _userFavoriListService;
        private readonly IProductPriceService _productPriceService;
        private readonly IMapper _mapper;

		public UserFavoriController(IUserFavoriService userFavoriListService, IProductPriceService productPriceService, IMapper mapper)
		{
			_userFavoriListService = userFavoriListService;
			_productPriceService = productPriceService;
			_mapper = mapper;
		}

		[HttpPost("CreateFavori")]
        public IActionResult CreateFavori([FromBody] CreateFavoriDto createFavoriDto)
        {

            var userFavListCheck = _userFavoriListService.TGetList().Find(x => x.userID == createFavoriDto.userID && x.priceID == createFavoriDto.priceID);
            if (userFavListCheck != null)
            {
                _userFavoriListService.TDelete(userFavListCheck);
                return Ok();
            }
            else
            {
                createFavoriDto.createDate = DateTime.Now;
                var result = _userFavoriListService.TInsertAsync(_mapper.Map<UserFavoriList>(createFavoriDto));
                if (result.IsCompleted)
                {
                    return Created();
                }
            }

            return BadRequest();
        }

		[HttpPost("DeleteFavori/{favoriID}")]
        public IActionResult DeleteFavori(int favoriID)
        {

            var userFavListCheck = _userFavoriListService.TGetList().Find(x => x.FavoriID== favoriID);
            if (userFavListCheck != null)
            {
                _userFavoriListService.TDelete(userFavListCheck);
                return Ok();
            }
           

            return BadRequest();
        }

        [HttpGet("ListFavori/{userID}")]
        public IActionResult ListFavori(string userID)
        {
			if (userID == null)
			{
				return BadRequest("User ID cannot be null.");
			}
			var list = _userFavoriListService.TGetListIncludeProductPrice().Where(x => x.userID == userID).ToList();
            return Ok(_mapper.Map<List<ResultListFavoriDto>>(list));
        }


    }
}
