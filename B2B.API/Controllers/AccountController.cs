using AutoMapper;
using B2B.API.Dtos.AccountDtos;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, signInDto.rememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(signInDto.UserName);
                if (user == null)
                {
                    return Unauthorized(); // Kullanıcı bulunamadı, uygun hata kodunu döndür
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new byte[32]; // 256-bit (32-byte) bir anahtar kullanıyoruz
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1), // Token geçerlilik süresi
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola.");
                return BadRequest(ModelState);
            }
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signupDto)
        {

            //var mailCheck = new System.Net.Mail.MailAddress(signupDto.Email);
            //var userLengthStatus = mailCheck.User.Length <= 5;

            //if (userLengthStatus || (mailCheck.Host != "gmail.com" && mailCheck.Host != "hotmail.com" && mailCheck.Host != "outlook.com"))
            //{
            //    ModelState.AddModelError("", "Mail Formatını Kontrol Edin!");
            //}



            if (!ModelState.IsValid)
            {
                return View(signupDto);
            }


            if (signupDto.Password != signupDto.PasswordR)
            {
                ModelState.AddModelError("", "Girilen şifreler uyuşmuyor.");
                return Ok(signupDto);
            }

            var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(signupDto), signupDto.Password);
            if (result.Succeeded)
            {

                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest();
            }
        }
    }
}
