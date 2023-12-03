using Business.Features.Roles;
using FluentValidation;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().WithMessage("Role Boş Olamaz");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role Adı Boş Olamaz");
        RuleFor(p => p.Name).NotNull().MinimumLength(3).WithMessage ("Role Adı Üç Karakterden Az Olamaz");
    }
}