using B2B.UI.DtosUI.ProductCategoryDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.CategoryFilter
{
    public class _CategoryFilter : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _CategoryFilter(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            try
            {
                var apiUrl = _appSettings.Value.ApiLayoutNavbar;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                    return View(value);
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
