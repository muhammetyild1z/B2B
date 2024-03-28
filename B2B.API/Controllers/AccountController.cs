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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
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

                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = new byte[32]; // 256-bit (32-byte) bir anahtar kullanıyoruz
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(key);
                //}
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new Claim[]
                //    {
                //new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.NameIdentifier, user.Id),
                //new Claim(ClaimTypes.Email, user.Email)
                //    }),
                //    Expires = DateTime.UtcNow.AddHours(1), // Token geçerlilik süresi
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                //};

                //var token = tokenHandler.CreateToken(tokenDescriptor);
                //var tokenString = tokenHandler.WriteToken(token);

                //return Ok(new { Token = tokenString });
                var issuer = _configuration["Jwt:ValidIssuer"];
                var audience = _configuration["Jwt:ValidAudience"];
                var key =  Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]); 
                //Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, user.UserName), 
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
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

            if (!ModelState.IsValid)
            {
                return View(signupDto);
            }


            if (signupDto.Password != signupDto.PasswordR)
            {
                ModelState.AddModelError("", "Girilen şifreler uyuşmuyor.");
                return Ok(signupDto);
            }
            signupDto.CreateDate= DateTime.Now;
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
