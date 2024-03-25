using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.DtosUI.ProductCategoryDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Slider1
{
    public class _SonEklenen : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _SonEklenen(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            try
            {
                var apiUrl = _appSettings.Value.ApiCokBegenilenUrl;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
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
