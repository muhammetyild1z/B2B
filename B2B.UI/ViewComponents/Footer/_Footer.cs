using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.ViewComponents.Footer
{
    public class _Footer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
