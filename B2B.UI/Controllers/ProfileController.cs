using B2B.UI.DtosUI.ProductPriceDtos;
using B2B.UI.DtosUI.UserFavoriDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace B2B.UI.Controllers
{
	public class ProfileController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly IOptions<AppSettings> _appSettings;

		public ProfileController(HttpClient httpClient, IOptions<AppSettings> appSettings)
		{
			_httpClient = httpClient;
			_appSettings = appSettings;
		}
		public async Task<IActionResult> FavoriList(string UserID)
		{
			 UserID = "3fe7b6fa-82fc-46ba-9087-c9590673aa51";
			var apiUrl = _appSettings.Value.ApiListFavori;
			HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + UserID);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var basketList = JsonConvert.DeserializeObject<List<ResultListFavoriDto>>(jsonData);
				return View(basketList);
			}

			return View();
		}
	}
}
