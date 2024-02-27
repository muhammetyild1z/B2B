using B2B.BusinessLayer.Abstract;
using B2B.UI.DtosUI.HomeSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.HomeSlider
{
    public class _HomeSlider : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _HomeSlider()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/HomeSlider/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("HomeSliderIncludeProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var homeSliderWithProduct = JsonConvert.DeserializeObject<List<ResultHomeSliderDto>>(jsonData);
                return View(homeSliderWithProduct);
            }
            else
            {
                return View(null);
            }
        }
    }
}
