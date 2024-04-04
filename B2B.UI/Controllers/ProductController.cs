using B2B.UI.DtosUI.FilterDto;
using B2B.UI.DtosUI.ProductCategoryDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace B2B.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public ProductController(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        public async Task<IActionResult> ProductDetails(int productID)
        {
            ViewBag.breadcrumb = "Ürün Detay";
            try
            {
                var apiUrl = _appSettings.Value.ApiProductPriceUrl;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + "/" + productID);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ResultProductPriceDto>(jsonData);
                    return View(value);
                }
                else
                {
                   

                    return Content("API isteği başarısız!");
                }
            }
            catch (Exception ex)
            {
                
                return Content($"API isteği sırasında bir hata oluştu: {ex.Message}");
            }

        }




    }
}
