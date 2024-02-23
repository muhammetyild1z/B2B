using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class HomeSliderValidation:AbstractValidator<HomeSlider>
    {
        public HomeSliderValidation()
        {
            RuleFor(x => x.SliderTitle).NotEmpty().WithMessage("Slider Başlığı Boş Geçilemez!")
                .MaximumLength(50).WithMessage("Slider Başlığı En Fazla 50 Karkter Olmalidir!")
                .MinimumLength(2).WithMessage("Slider Başlığı En Az 2 Karkter Olmalidir!");

            RuleFor(x => x.SliderDescription).NotEmpty().WithMessage("Slider Açıklaması Boş Geçilemez!")
             .MaximumLength(50).WithMessage("Slider Açıklaması En Fazla 50 Karkter Olmalidir!")
             .MinimumLength(2).WithMessage("Slider Açıklaması En Az 2 Karkter Olmalidir!");

            RuleFor(x => x.ProductID).NotEmpty().WithMessage("Ürün Boş Geçilemez!");



        }
    }
}
