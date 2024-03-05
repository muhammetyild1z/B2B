using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/Product/");
            _httpClient.DefaultRequestHeaders.Clear();
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
    }
}
