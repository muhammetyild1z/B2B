using B2B.UI.DtosUI.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.CokBegenilen
{
    public class _CokBegenilen:ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _CokBegenilen()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/Product/");
            _httpClient.DefaultRequestHeaders.Clear();

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
