using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.DimensionsFilter
{
    public class _DimensionsFilter:ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public _DimensionsFilter(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var apiUrl = _appSettings.Value.ApiGetAllDimensionsUrl;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basketList = JsonConvert.DeserializeObject<List<ResultDimensionsDto>>(jsonData);
                return View(basketList);
            }

            return View();
        }
    }
}
