using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Slider1
{
    public class _SonEklenen : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _SonEklenen(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ProductPrice");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("GetAllProductPrice");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var cokBegenilen = JsonConvert.DeserializeObject<List<ResultProductPriceDto>>(jsonData);

                return View(cokBegenilen);
            }
            return View();
        }
    }
}
