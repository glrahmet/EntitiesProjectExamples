using EntitiesProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Categories.GetQueryCategories
{
    public sealed record GetCategoriesQueryCommand : IRequest<List<Category>>;

}
