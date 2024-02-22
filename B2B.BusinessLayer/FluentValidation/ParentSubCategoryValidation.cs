
using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ParentSubCategoryValidation : AbstractValidator<ParentSubCategory>
    {
        public ParentSubCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!")
        .MaximumLength(50).WithMessage("Kategori Adı En Fazla 50 Karakter Olabilir!")
        .MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakter Olmalıdır!");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Kategori Durumu Boş Geçilemez!");

            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("Kategori Eklenme Tarihi Boş Geçilemez!");
        }
    }
}
