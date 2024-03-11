using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient1;

        public ProductController(IHttpClientFactory httpClientFac)
        {
            _httpClient = httpClientFac.CreateClient("Product");  
            _httpClient1 = httpClientFac.CreateClient("Productdimensions");
          
     
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ProductDetails(int productID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"GetByIdProduct/{productID}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var productDetail = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                return View(productDetail);
            }
            return View();
        }

        public async Task<IActionResult> GetProductDimensionId(int id)
        {
            HttpResponseMessage response = await _httpClient1.GetAsync($"GetByIdDimension/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
              
                return Ok(jsonData);
            }
            return NotFound ();
        }

    }
}
