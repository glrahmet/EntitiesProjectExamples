using Business.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.UpdateProduct
{
    public sealed record UpdateProductCommand(ProductModel ProductModel) : IRequest
    {
    }
}
