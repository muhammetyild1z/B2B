﻿using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
