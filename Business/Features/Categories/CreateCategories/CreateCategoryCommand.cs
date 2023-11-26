using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Categories.CreateCategories
{
    //record bir defaya mahsus türetilen ikincisinde class yapısının değişitirilmesine izin verilmeyen yapıdır.
    public sealed record CreateCategoryCommand(string CategoryName) : IRequest;
}
