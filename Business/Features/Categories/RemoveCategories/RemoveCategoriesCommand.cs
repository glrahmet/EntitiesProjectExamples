using EntitiesProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Categories.RemoveCategories
{
    public sealed record RemoveCategoriesCommand(Guid Id) : IRequest
    {
    }
} 