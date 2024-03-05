using B2B.UI.DtosUI.DimensionsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Dimensions
{
    public class _Dimensions : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _Dimensions(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Productdimensions");
        }
        public async Task<IViewComponentResult> InvokeAsync(int ProductID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"GetProductWithDimensions/{ProductID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var dimensions = JsonConvert.DeserializeObject<List<ResultDimensionsDto>>(jsonData);
                return View(dimensions);
            }
            else
            {
                
                return View();
            }
        }

    }
}
