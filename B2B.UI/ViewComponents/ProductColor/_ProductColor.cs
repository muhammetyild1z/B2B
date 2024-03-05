
using B2B.UI.DtosUI.ProductColorDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductColor
{
    public class _ProductColor : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _ProductColor(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ProductColor");
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"GetProductColor/{productID}");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var colors= JsonConvert.DeserializeObject<List<ResultProductColorDto>>(jsonData);
                return View(colors);

            }
            return View();
        }
    }
}
