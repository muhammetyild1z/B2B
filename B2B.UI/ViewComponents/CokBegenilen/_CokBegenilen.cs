using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace B2B.UI.ViewComponents.CokBegenilen
{
    public class _CokBegenilen:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _CokBegenilen(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Product");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("AllGetProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var cokBegenilen= JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(cokBegenilen);
            }
            return View();
        }
    }
}
