
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
        [HttpPost]
        public async Task<IActionResult> ResultContactMailRequest(CreateContactMailRequestDto createContactMailRequestDto, ContactMailRequest a)
        {
           
            ContactMailRequestValidation validator = new ContactMailRequestValidation();
            ValidationResult validationresult = validator.Validate(a);

           
            if (!validationresult.IsValid)
            {           
                foreach (var error in validationresult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }              
                return BadRequest(ModelState);
            }
            var jsonData = JsonConvert.SerializeObject(createContactMailRequestDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
         
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("CreateContactMailRequest", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok(); 
            }
            return NotFound();

        }
    }
}
