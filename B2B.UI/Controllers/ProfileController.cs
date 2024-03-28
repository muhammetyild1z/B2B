using B2B.EntityLayer.Concrate;
using B2B.UI.DtosUI.UserFavoriDtos;
using B2B.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using System.Security.Claims;

namespace B2B.UI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly UserManager<AppUser> _appUser;

		public ProfileController(HttpClient httpClient, IOptions<AppSettings> appSettings, UserManager<AppUser> appUser)
		{
			_httpClient = httpClient;
			_appSettings = appSettings;
			_appUser = appUser;
		}

		public async Task<IActionResult> FavoriList()
        {
            ViewBag.breadcrumb = "Favorilerim";
            if (!User.Identity.IsAuthenticated)
			{
                List<ResultListFavoriDto> model = new List<ResultListFavoriDto>();
                return View(model);
            }
            var apiUrl = _appSettings.Value.ApiListFavori;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basketList = JsonConvert.DeserializeObject<List<ResultListFavoriDto>>(jsonData);
                return View(basketList);
            }

            return View();
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.breadcrumb = "Profilim";
            if (User.Identity.IsAuthenticated)
            {
                var user = await _appUser.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(user);
            }

            return View();
		}
    }
}
