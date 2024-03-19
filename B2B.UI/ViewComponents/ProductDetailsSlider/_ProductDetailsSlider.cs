using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace B2B.UI.ViewComponents.ProductDetailsSlider
{
    public class _ProductDetailsSlider:ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View();
        }
    }
}
