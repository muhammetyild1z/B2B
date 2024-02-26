using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
