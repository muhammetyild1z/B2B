using B2B.EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.FluentValidation
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.ContactDesc)
            .MaximumLength(300).WithMessage("Aciklama Kismi En Fazla 500 karakter Olabilir!")
            .MinimumLength(10).WithMessage("Aciklama Kismi En Az 10 karakter Olabilir!");

            RuleFor(x => x.ContactMail1)
               .NotEmpty().WithMessage("Mail 1 Adresi Bos Gecilemez!")
               .EmailAddress().WithMessage("Mail Tipini Kontrol Edin!")
           .MaximumLength(100).WithMessage("Mail Kismi En Fazla 100 karakter Olabilir!")
           .MinimumLength(10).WithMessage("Mail Kismi En Az 10 karakter Olabilir!");

            RuleFor(x => x.ContactMail2)

               .EmailAddress().WithMessage("Mail Tipini Kontrol Edin!")
           .MaximumLength(100).WithMessage("Mail Kismi En Fazla 100 karakter Olabilir!")
           .MinimumLength(10).WithMessage("Mail Kismi En Az 10 karakter Olabilir!");


            RuleFor(x => x.ContactAdress)
                .NotEmpty().WithMessage("Adres Bos Gecilemez!")
            .MaximumLength(300).WithMessage("Adres Kismi En Fazla 500 karakter Olabilir!")
            .MinimumLength(10).WithMessage("Adres Kismi En Az 10 karakter Olabilir!");

            RuleFor(x => x.ContactPhone1)
                .NotEmpty().WithMessage("Telefon 1 Bos Gecilemez!")
            .Length(11).WithMessage("Telefon Numaranizi 11 Hane Olarak Girin")
             .Matches(@"[0-9]+").WithMessage("Telefon 1 numarası sadece rakam içermelidir.");

            RuleFor(x => x.ContactPhone2)

          .Length(11).WithMessage("Telefon Numaranizi 11 Hane Olarak Girin")
           .Matches(@"[0-9]+").WithMessage("Telefon 2 numarası sadece rakam içermelidir.");


        }
    }
}
