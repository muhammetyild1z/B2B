using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Slider1
{
    public class _Slider1 : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _Slider1()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/Product/");
            _httpClient.DefaultRequestHeaders.Clear();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("AllGetProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var cardSlider= JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(cardSlider);
            }
            return View();
        }
    }
}
