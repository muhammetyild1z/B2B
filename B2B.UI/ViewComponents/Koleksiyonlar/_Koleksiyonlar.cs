using B2B.BusinessLayer.Abstract;
using B2B.UI.DtosUI.DimensionsDtos;
using B2B.UI.DtosUI.ProductDtos;
using B2B.UI.DtosUI.ProductPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace B2B.UI.ViewComponents.Koleksiyonlar
{
    public class _Koleksiyonlar : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
      
            return View();
        }
    }
}

