using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
