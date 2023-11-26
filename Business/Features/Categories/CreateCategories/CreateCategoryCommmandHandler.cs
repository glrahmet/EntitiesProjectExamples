using EntitiesProject.Models;
using MediatR;

namespace Business.Features.Categories.CreateCategories
{
    internal sealed class CreateCategoryCommmandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommmandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var isCategoryNameExits = await _categoryRepository.AnyAsync(k => k.CategoryName == request.CategoryName);
            if (!isCategoryNameExits)
            {
                Category category = new();
                category.CategoryName = request.CategoryName;

                await _categoryRepository.AddAsync(category, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
                throw new ArgumentException("Bu kategori daha önce eklenmiştir.");
        }
    }
}
