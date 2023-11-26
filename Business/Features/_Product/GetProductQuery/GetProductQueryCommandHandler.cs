using EntitiesProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.GetProductQuery
{
    internal sealed class GetProductQueryCommandHandler : IRequestHandler<GetProductQueryCommand, List<Product>>
    {
        private readonly IProductRepository _productRepository;
        public async Task<List<Product>> Handle(GetProductQueryCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll().OrderBy(k => k.ProductName).ToListAsync();
        }
    }
}
