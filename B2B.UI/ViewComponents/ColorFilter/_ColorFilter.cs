using B2B.UI.DtosUI.ColorDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ColorFilter
{
    public class _ColorFilter : ViewComponent
    {

        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _ColorFilter(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var apiUrl = _appSettings.Value.ApiColorFilterUrl;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basketList = JsonConvert.DeserializeObject<List<ResultColorDto>>(jsonData);
                return View(basketList);
            }

            return View();
        }
    }
}
