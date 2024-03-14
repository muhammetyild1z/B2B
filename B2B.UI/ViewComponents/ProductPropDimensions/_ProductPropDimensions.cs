using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductPropDimensions
{
    public class _ProductPropDimensions : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _ProductPropDimensions(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Dimensions");
        }
        public async Task<IViewComponentResult> InvokeAsync( int productID)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"GetByIDProductSize/{productID}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var productDimensions = JsonConvert.DeserializeObject<List<ResultDimensionsDto>>(jsonData);

                return View(productDimensions);
            }
            return View();
        }
    }
}
