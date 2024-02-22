using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Ürün fiyatı Boş Geçilemez!")
            .Must(BeDecimal).WithMessage("Ürün fiyatı bir ondalık sayı olmalıdır!");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Açıklama Kısmı Boi Geçilemez!")
                .MaximumLength(300).WithMessage("Açıklama En Fazla 300 Karakter Olabılır!")
                .MinimumLength(10).WithMessage("Açıklama En Az 10 Karakter Olabılır!");

            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Ürün Resmi  Boş Geçilemez!");
        }

        private bool BeDecimal(decimal value)
        {
            return true;
        }
    }
}
