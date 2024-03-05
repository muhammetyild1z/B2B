using B2B.BusinessLayer.Abstract;
using B2B.UI.DtosUI.HomeSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace B2B.UI.ViewComponents.HomeSlider
{
    public class _HomeSlider : ViewComponent
    {
        private readonly HttpClient _homeSliderHttpClient;

        public _HomeSlider(IHttpClientFactory httpClientFactory)
        {
            _homeSliderHttpClient = httpClientFactory.CreateClient("HomeSlider");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _homeSliderHttpClient.GetAsync("HomeSliderIncludeProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var homeSliderWithProduct = JsonConvert.DeserializeObject<List<ResultHomeSliderDto>>(jsonData);
                return View(homeSliderWithProduct);
            }
            else
            {
                return View(null);
            }
        }
    }
}
