using AutoMapper;
using EntitiesProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features._Product.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isProduct = await _repository.AnyAsync(k => k.ProductName == request.ProductModel.ProductName);
            if (!isProduct)
            {
                Product product = _mapper.Map<Product>(request);

                await _repository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            }
            else
                throw new ApplicationException("Bu isimde bir product bulunmaktadır");

            return Unit.Value;
        }
    }
}
