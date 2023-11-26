using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.RemoveProduct
{
    public sealed record RemoveProductCommand(Guid productId) : IRequest;

}
