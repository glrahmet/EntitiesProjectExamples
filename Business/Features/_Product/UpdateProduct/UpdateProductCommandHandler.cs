using EntitiesProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var isProduct = await _productRepository.GetFindFirstExpression(k => k.Id == request.ProductModel.Id);
            if (isProduct != null)
            {
                isProduct.ProductName = request.ProductModel.ProductName;
                isProduct.Price = request.ProductModel.Price;
                isProduct.Quantity = request.ProductModel.Quantity;
                isProduct.CategoryId = request.ProductModel.CategoryId;

                _productRepository.Update(isProduct);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            }
            else
                throw new ApplicationException("Güncellemek istediğiniz product bilgisi bulunmamaktadır.");
        }
    }
}
