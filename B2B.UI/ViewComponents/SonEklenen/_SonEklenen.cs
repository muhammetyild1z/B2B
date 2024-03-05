using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Slider1
{
    public class _SonEklenen : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _SonEklenen(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Product");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("AllGetProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var sonEklenen= JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(sonEklenen.OrderByDescending(x=>x.CreateDate).ToList());
            }
            return View();
        }
    }
}
