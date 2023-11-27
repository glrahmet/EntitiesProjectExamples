using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalıdır.");

            RuleFor(p => p.Name).NotEmpty().WithMessage("Ad Alanı Boş Olamaz");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ad Alanı Boş Olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ad Alanı En Az 3 Karakter Olmalıdır.");

            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyadı Boş Olamaz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyadı Boş Olamaz");
            RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Soyadı Alanı En Az 3 Karekter Olmalıdır.");

            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Boş Olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Boş Olamaz");
            RuleFor(p => p.Email).MinimumLength(3).WithMessage("Email Alanı En Az 3 Karekter Olmalıdır.");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Password Boş Olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password Boş Olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Password Alanı En Az 6 Karekter Olmalıdır.");


            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Password Alanı En Az 1 Adet Büyük Harf İçermelidir.");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Password Alanı En Az 1 Adet Küçük Harf İçermelidir.");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Password Alanı En Az 1 Adet Rakam İçermelidir.");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password En Az 1 Adet Özel Karakter İçermelidir.");



        }
    }
}
