using AutoMapper;
using B2B.API.Dtos.AccountDtos;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;

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
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, false, false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signupDto)
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
                return View(signupDto);
            }

            var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(signupDto), signupDto.Password);
            if (result.Succeeded)
            {

                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(signupDto);
            }
        }
    }
}
