using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class LayoutController : Controller
    {

        public IActionResult LayoutIndex()
        {
            return View();
        }
    }
}
