
using B2B.BusinessLayer.FluentValidation;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.ContactMailRequestDtos;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace B2B.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;
       

        public ContactController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/ContactMailRequest/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
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
            StringContent stringContent = new StringContent(jsonData);
            //type hatasu var
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("CreateContactMailRequest", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok(); 
            }
            return NotFound();

        }
    }
}
