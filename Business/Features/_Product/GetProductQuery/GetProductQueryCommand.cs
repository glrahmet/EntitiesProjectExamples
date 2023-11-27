using EntitiesProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.GetProductQuery
{
    public sealed record GetProductQueryCommand : IRequest<List<Product>>;

}
