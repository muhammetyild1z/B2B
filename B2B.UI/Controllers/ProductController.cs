﻿using Microsoft.AspNetCore.Mvc;

namespace B2B.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult ProductDetails(int productID)
        {
            return View();
        }
    }
}
