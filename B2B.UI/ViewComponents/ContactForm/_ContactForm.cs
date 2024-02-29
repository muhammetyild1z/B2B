using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.ViewComponents.ContactForm
{
    public class _ContactForm:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
