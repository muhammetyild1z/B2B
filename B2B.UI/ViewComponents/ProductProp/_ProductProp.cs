using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductProp
{
    public class _ProductProp : ViewComponent
    {

        private readonly HttpClient _httpClient;

        public _ProductProp(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ProductPrice");
        }
        public async Task<IViewComponentResult> InvokeAsync(int priceID)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"GetByIdProductPrice/{priceID}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var productProp = JsonConvert.DeserializeObject<ResultProductPriceDto>(jsonData);

                return View(productProp);
            }
            return View();
        }
    }
}