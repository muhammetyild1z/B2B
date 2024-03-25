using B2B.UI.DtosUI.ContactMailRequestDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace B2B.UI.ViewComponents.ContactForm
{
    public class _ContactForm:ViewComponent
    {
        //private readonly HttpClient _httpClient;
        //private readonly IOptions<AppSettings> _appSettings;

        //public _ContactForm(HttpClient httpClient, IOptions<AppSettings> appSettings)
        //{
        //    _httpClient = httpClient;
        //    _appSettings = appSettings;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
          
                return View();

            
        
        //    try
        //    {
        //        var apiUrl = _appSettings.Value.ApiContactMailRequestUrl;
        //        var requestData = JsonConvert.SerializeObject(createContactMailRequestDto);
        //        var content = new StringContent(requestData, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonData = await response.Content.ReadAsStringAsync();
        //            return Content(jsonData);
                  
        //        }
        //        else
        //        {
        //            // API'den başarısız bir yanıt alındığında burada işlemler yapabilirsiniz.
        //            // Örneğin: Loglama, hata mesajı gösterimi vs.
        //            return Content("API isteği başarısız!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Herhangi bir hata durumunda burada işlemler yapabilirsiniz.
        //        // Örneğin: Loglama, istisna fırlatma vs.
        //        return Content($"API isteği sırasında bir hata oluştu: {ex.Message}");
        //    }
        }
    }
}
