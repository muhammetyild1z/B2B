using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.FilterDto;
using B2B.UI.DtosUI.ProductCategoryDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace B2B.UI.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public ProductCategoryController(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public async Task<IActionResult> CategoryList(int categoryId, int subcategory)
        {
            ViewBag.breadcrumb = "Tüm Ürünler";
            if (categoryId != 0)
            {
                var apiUrl1 = _appSettings.Value.ApiGetIncludeProductCategoryUrl;
                HttpResponseMessage response1 = await _httpClient.GetAsync(apiUrl1 + categoryId);
                if (response1.IsSuccessStatusCode)
                {
                    var jsonData = await response1.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                    return View(productList);
                }
            }
            else if (subcategory != 0)
            {
                var apiUrl2 = _appSettings.Value.ApiGetIncludeProductSubCategoryUrl;
                HttpResponseMessage response2 = await _httpClient.GetAsync(apiUrl2 + subcategory);
                if (response2.IsSuccessStatusCode)
                {
                    var jsonData = await response2.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                    return View(productList);
                }
            }

            var apiUrl = _appSettings.Value.ApiAllGetProductCategoryUrl;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var productList = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                return View(productList);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryList([FromBody] FilterDto filter)
        {
            var apiUrl = _appSettings.Value.FilterCategory;
            var jsonFilter = JsonConvert.SerializeObject(filter);
            var content = new StringContent(jsonFilter, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var productList = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                return Ok(productList);
            }
            return View();
        }


    }
}
