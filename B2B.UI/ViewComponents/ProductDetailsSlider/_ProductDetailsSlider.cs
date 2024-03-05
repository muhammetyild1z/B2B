using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.ProductDetailsSlider
{
    public class _ProductDetailsSlider:ViewComponent
    {
        
        private readonly HttpClient _httpClient;

        public _ProductDetailsSlider(IHttpClientFactory _clientFactory)
        {
            _httpClient = _clientFactory.CreateClient("Product");
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("AllGetProduct");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(product);
            }

            return View();
        }
    }
}
