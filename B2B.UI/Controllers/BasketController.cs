using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.BasketDtos;
using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace B2B.UI.Controllers
{
    [Route("Basket")]
    public class BasketController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient1;

        public BasketController(IHttpClientFactory httpClientFac)
        {
            _httpClient = httpClientFac.CreateClient("Productdimensions");
            _httpClient1 = httpClientFac.CreateClient("Basket");

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("BasketAdd")]
        public async Task< IActionResult> BasketAdd([FromBody] CreateBasketDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
         
            HttpResponseMessage responseMessage = await _httpClient1.PostAsync("CreateBasket", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok();
            }
            return Ok();
        }
    }

}

