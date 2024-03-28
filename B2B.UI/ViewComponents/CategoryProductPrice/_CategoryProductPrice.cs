using B2B.UI.DtosUI.ProductPriceDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.CategoryProductPrice
{
    public class _CategoryProductPrice : ViewComponent
    {

        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _CategoryProductPrice(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            try
            {
                var apiUrl = _appSettings.Value.ApiCategoryProductPriceUrl;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + productId);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var productPrice = JsonConvert.DeserializeObject<ResultProductPriceDto>(jsonData);
                    return View(productPrice.price);
                }
                return View(null);

            }
            catch (Exception ex)
            {
                // Herhangi bir hata durumunda burada işlemler yapabilirsiniz.
                // Örneğin: Loglama, istisna fırlatma vs.
                return Content($"API isteği sırasında bir hata oluştu: {ex.Message}");
            }
        }
    }
}

