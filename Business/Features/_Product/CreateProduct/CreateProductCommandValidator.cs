using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.CreateProduct
{
    internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductModel.ProductName).NotEmpty().WithMessage("Product Adı Boş Olamaz");
            RuleFor(p => p.ProductModel.ProductName).NotNull().WithMessage("Product Adı Boş Olamaz");
            RuleFor(p => p.ProductModel.CategoryId).NotNull().WithMessage("Category Id Boş Olamaz");
            RuleFor(p => p.ProductModel.CategoryId).NotEmpty().WithMessage("Category Id Boş Olamaz");
        }
    }
}
