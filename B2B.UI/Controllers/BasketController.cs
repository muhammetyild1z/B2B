using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.BasketDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace B2B.UI.Controllers
{

	public class BasketController : Controller
	{

		private readonly HttpClient _httpClient;
		private readonly IOptions<AppSettings> _appSettings;

		public BasketController(HttpClient httpClient, IOptions<AppSettings> appSettings)
		{
			_httpClient = httpClient;
			_appSettings = appSettings;
		}
		[Authorize]
		public async Task<IActionResult> BasketList()
		{
            ViewBag.breadcrumb = "Sepetim";
            if (User.Identity.IsAuthenticated)
			{
				var apiUrl = _appSettings.Value.ApiUserBasketUrl;
				HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + User.FindFirstValue(ClaimTypes.NameIdentifier));
				if (response.IsSuccessStatusCode)
				{
					var jsonData = await response.Content.ReadAsStringAsync();
					var basketList = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
					return View(basketList);
				}
			}
	
			return View();
		}

	

	}

}

