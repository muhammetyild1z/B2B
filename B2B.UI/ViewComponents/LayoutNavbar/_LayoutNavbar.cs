using B2B.UI.DtosUI.ProductCategoryDtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace B2B.UI.ViewComponents.LayoutHeaderPartial
{
    public class _LayoutNavbar : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _LayoutNavbar()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/ProductCategory/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();

        }
        public async Task<IViewComponentResult> InvokeAsync()

        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("AllGetProductCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
