using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetFindFirstExpression(k => k.Id == request.ProductModel.Id);
            if (product != null)
            {
                _mapper.Map(request, product); 
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            }
            else
                throw new ApplicationException("Güncellemek istediğiniz product bilgisi bulunmamaktadır.");
        }
    }
}
