using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ContactMailRequestValidation : AbstractValidator<ContactMailRequest>
    {
        public ContactMailRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(" Ad Boş Geçilemez!")
         .MaximumLength(50).WithMessage("Kategori Adı En Fazla 50 Karakter Olabilir!")
         .MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakter Olmalıdır!");

              RuleFor(x => x.Message).NotEmpty().WithMessage(" Mesaj Boş Geçilemez!")
         .MaximumLength(500).WithMessage("Mesaj En Fazla 50 Karakter Olabilir!")
         .MinimumLength(10).WithMessage("Mesaj En Az 10 Karakter Olmalıdır!");

            RuleFor(x => x.Phone).NotEmpty().WithMessage(" Ad Boş Geçilemez!")
    .Length(11).WithMessage("Telefon Numarasini 11 Hane Olacak sekilde tuslayin!")
                .Matches(@"[0-9]+").WithMessage("Telefon numarası sadece rakam içermelidir.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Boş Geçilemez!")
         .MaximumLength(100).WithMessage("Kategori Adı En Fazla 50 Karakter Olabilir!")
        .EmailAddress().WithMessage("Email Formatinda olmali");
        }
    }
}
