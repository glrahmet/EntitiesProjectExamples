using EntitiesProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isProduct = await _repository.AnyAsync(k => k.ProductName == request.ProductModel.ProductName);
            if (!isProduct)
            {
                Product product = new();
                product.ProductName = request.ProductModel.ProductName;
                product.Quantity = request.ProductModel.Quantity;
                product.Price = request.ProductModel.Price;
                product.CategoryId = request.ProductModel.CategoryId;

                await _repository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            }
            else
                throw new ApplicationException("Bu isimde bir product bulunmaktadır");

        }
    }
}
