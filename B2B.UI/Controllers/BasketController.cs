using B2B.BusinessLayer.Abstract;
using B2B.UI.DtosUI.BasketDtos;
using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace B2B.UI.Controllers
{
    public class BasketController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient1;

        public BasketController(IHttpClientFactory httpClientFac)
        {
            _httpClient = httpClientFac.CreateClient("Product");
            _httpClient1 = httpClientFac.CreateClient("Basket");
            
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BasketAdd(int id)
        {
            if (id != 0)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    
                    if (userId == null)
                    {
                        return BadRequest();
                    }

                    HttpResponseMessage response =await _httpClient.GetAsync($"GetByIdProduct/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonData= await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

                        CreateBasketDto CreateBasket = new CreateBasketDto()
                        {
                            UserID= userId,
                            ProductID=product.Product_ID,
                           
                        };
                        var jsonDataBasket = JsonConvert.SerializeObject(CreateBasket);
                        StringContent content = new StringContent(jsonDataBasket, Encoding.UTF8, "application/json");
                        HttpResponseMessage responseBasket = await _httpClient1.PostAsync("CreateBasket", content);
                        if (responseBasket.IsSuccessStatusCode)
                        {
                            return Ok();
                        }
                     
                    }
                }

                else
                {
                    return Unauthorized();
                }
            }
            return NotFound();

        }

    }
}
