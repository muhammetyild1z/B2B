using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ProductColorValidation:AbstractValidator<ProductColor>
    {
        public ProductColorValidation()
        {
                RuleFor(x=>x.ProductID).NotEmpty().WithMessage("Ürün boş geçilemez!!");
                RuleFor(x=>x.ColorCode).NotEmpty().WithMessage("Ürün Renk Kodu boş geçilemez!!");
                RuleFor(x=>x.Status).NotEmpty().WithMessage("Ürün Durumu boş geçilemez!!");
                RuleFor(x=>x.CreateDate).NotEmpty().WithMessage("Tarih atama sorunu!!");
        }
    }
}
