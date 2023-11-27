using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Login
{
    public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalıdır.");
             
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
