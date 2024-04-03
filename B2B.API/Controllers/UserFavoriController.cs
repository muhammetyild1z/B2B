using AutoMapper;
using B2B.API.Dtos.ProductPriceDtos;
using B2B.API.Dtos.ProfileDtos;
using B2B.API.Dtos.UserFavoriDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFavoriController : Controller
    {
        private readonly IUserFavoriService _userFavoriListService;
        private readonly IProductPriceService _productPriceService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserFavoriController(IUserFavoriService userFavoriListService, IProductPriceService productPriceService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userFavoriListService = userFavoriListService;
            _productPriceService = productPriceService;
            _userManager = userManager;
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

            var userFavListCheck = _userFavoriListService.TGetList().Find(x => x.FavoriID == favoriID);
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

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateModel model)
        {
            var mailCheck = new System.Net.Mail.MailAddress(model.Email);
            var userLengthStatus = mailCheck.User.Length <= 5;

            if (userLengthStatus || (mailCheck.Host != "gmail.com" && mailCheck.Host != "hotmail.com" && mailCheck.Host != "outlook.com"))
            {
                ModelState.AddModelError("", "Mail Formatını Kontrol Edin!");
            }
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

    }
}
