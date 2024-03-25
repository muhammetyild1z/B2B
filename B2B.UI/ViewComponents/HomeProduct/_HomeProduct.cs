using B2B.UI.DtosUI.ProductPriceDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;

namespace B2B.UI.ViewComponents.HomeProduct
{
	public class _HomeProduct:ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _HomeProduct(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public async Task< IViewComponentResult> InvokeAsync(int productID)
        {

            try
            {
                var apiUrl = _appSettings.Value.ApiGetAllProductPriceByProductID;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl+ productID);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<ResultProductPriceDto>(jsonData);
                    return View(productList);
                }
                else
                {
                    // API'den başarısız bir yanıt alındığında burada işlemler yapabilirsiniz.
                    // Örneğin: Loglama, hata mesajı gösterimi vs.
                    return Content("API isteği başarısız!");
                }
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
