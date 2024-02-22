using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ProductCategoryValidation:AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidation()
        {
            RuleFor(x=>x.CategoryID).NotEmpty().WithMessage("Kategori Boş Geçilemez!!");
           
        }
    }
}
