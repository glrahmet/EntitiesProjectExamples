using Business.Features.Categories.CreateCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Roles
{
    public sealed record CreateRoleCommand(string Name) : IRequest<Unit>;

}

