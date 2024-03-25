
using B2B.BusinessLayer.FluentValidation;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.ContactMailRequestDtos;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace B2B.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;
     
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ContactMailRequest");
        }


     

        public IActionResult Index()
        {
            return View();
        }
    
    }
}
