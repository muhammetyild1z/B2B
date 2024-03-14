using B2B.UI.DtosUI.ProductColorDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductPropColor
{
    public class _ProductPropColor:ViewComponent
    {

        private readonly HttpClient _httpClient;

        public _ProductPropColor(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ProductPrice");
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"GetProductColor/{productID}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var productColor = JsonConvert.DeserializeObject<List<ResultProductColorDto>>(jsonData);

                return View(productColor);
            }
            return View();
        }
    }
}
