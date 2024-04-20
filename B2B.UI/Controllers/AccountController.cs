using AutoMapper;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

       

        public IActionResult SignIn()
        {
            ViewBag.breadcrumb = "Giriş yap";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto, string returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, signInDto.memberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("index", "home");
                }

            }
            else
            {
                ModelState.AddModelError("", "Kullanici adi veya şifre hatalı.");

                if (!ModelState.IsValid)
                {
                    ViewBag.ErrorCount = ModelState.ErrorCount;
                }

                return View();
            }
        }


        public async Task<IActionResult> SignOutUser()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("SignIn", "Account");
        }

        [HttpPost]
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
            signupDto.CreateDate = DateTime.Now;
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
