using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace B2B.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient1;
        private readonly HttpClient _httpClient2;

        public ProductController(IHttpClientFactory httpClientFac)
        {
            _httpClient = httpClientFac.CreateClient("Product");  
            _httpClient1 = httpClientFac.CreateClient("Productdimensions");
            _httpClient2 = httpClientFac.CreateClient("ProductPrice");
          
     
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ProductDetails(int priceID)
        {
            HttpResponseMessage response = await _httpClient2.GetAsync($"GetByIdProductPrice/{priceID}");
            if (response.IsSuccessStatusCode)
            {
              
                var jsonData = await response.Content.ReadAsStringAsync();
                var productDetail = JsonConvert.DeserializeObject<ResultProductPriceDto>(jsonData);
                return View(productDetail);
            }
            return View();
        }

    

        [HttpPost] 
        public async Task<IActionResult> GetProductDimension([FromBody] CreateProductPriceDto dto)
        {
            
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient2.PostAsync("GetProductDimension", stringContent);   
            if (response.IsSuccessStatusCode)
            {
                var priceWithPriceID = await response.Content.ReadAsStringAsync();
                JsonConvert.SerializeObject(priceWithPriceID);
                return Ok(priceWithPriceID);
            }
            return NotFound();
        }
    }
}
