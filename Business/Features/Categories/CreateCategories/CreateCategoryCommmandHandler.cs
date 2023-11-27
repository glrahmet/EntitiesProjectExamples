using AutoMapper;
using EntitiesProject.Models;
using MediatR;

namespace Business.Features.Categories.CreateCategories
{
    internal sealed class CreateCategoryCommmandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCategoryCommmandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var isCategoryNameExits = await _categoryRepository.AnyAsync(k => k.CategoryName == request.CategoryName);
            if (!isCategoryNameExits)
            {
                Category category = _mapper.Map<Category>(request.CategoryName); 
                await _categoryRepository.AddAsync(category, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
                throw new ArgumentException("Bu kategori daha önce eklenmiştir.");
        }
    }
}
