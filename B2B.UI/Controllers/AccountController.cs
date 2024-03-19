using B2B.UI.DtosUI.AccountDtos;
using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult SignIn()
        {
            return View();
        }

 
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
