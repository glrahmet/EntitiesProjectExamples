using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.RemoveProduct
{
    internal sealed class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetFindFirstExpression(k => k.Id == request.productId);
            if (product == null)
            {
                _repository.Remove(product);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
                throw new ApplicationException("Id bilgisine ait product bilgisi bulunmamaktadır.");
        }
    }
}
