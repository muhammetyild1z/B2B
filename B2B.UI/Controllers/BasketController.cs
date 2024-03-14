using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.BasketDtos;
using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace B2B.UI.Controllers
{
   
    public class BasketController : Controller
    {
        
        private readonly HttpClient _httpClient1;

        public BasketController(IHttpClientFactory httpClientFac)
        {
          
            _httpClient1 = httpClientFac.CreateClient("Basket");

        }
    
        public async Task< IActionResult> BasketList(int id)
        {
            HttpResponseMessage response = await _httpClient1.GetAsync($"UserAllBasket/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var basketList= JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(basketList);
            }
             
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BasketAdd([FromBody] CreateBasketDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient1.PostAsync("CreateBasket", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok();
            }
            return Unauthorized();
        }
    }

}

