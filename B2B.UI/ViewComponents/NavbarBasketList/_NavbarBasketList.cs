using B2B.UI.DtosUI.BasketDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.NavbarBasketList
{
    public class _NavbarBasketList : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _NavbarBasketList(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            if (userId == null)
            {
               List< ResultBasketDto > a = new List< ResultBasketDto >();
                return View(a);
            }
            try
            {
                var apiUrl = _appSettings.Value.ApiUserBasketUrl;
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl+ userId);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var basketList = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                    return View(basketList);
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
