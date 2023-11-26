using Business.Features.Categories.UpdateCategories;
using EntitiesProject.Models;
using MediatR;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.FindAsync(k => k.Id == request.Id);
        if (category == null)
        {
            category.CategoryName = request.CategoryName;
            await _unitOfWork.SaveChangesAsync();
        }
        else
            throw new ApplicationException("Id bilgisine ait kategori bilgisi bulunmamaktadır.");
    }
}
