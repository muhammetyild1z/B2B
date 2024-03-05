using B2B.UI.DtosUI.ProductStockDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductStock
{
    public class _ProductStock:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _ProductStock(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ProductStock");
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"GetProductStock/{productID}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var stockCount= JsonConvert.DeserializeObject<ProductStockDto>(jsonData);
                return View(stockCount);
            }
                return View();
        }
    }
}
