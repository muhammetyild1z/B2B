using B2B.UI.DtosUI.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Contact
{
    public class _Contact : ViewComponent
    {
     
         private readonly HttpClient _httpClient;
        public _Contact(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Contact");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("AllGetContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var contactList= JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
               return View(contactList);
            }
            return View();
        }
    }
}
