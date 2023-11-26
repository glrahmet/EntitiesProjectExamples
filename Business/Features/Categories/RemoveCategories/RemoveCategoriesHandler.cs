using Business.Features.Categories.RemoveCategories;
using MediatR;

internal sealed class RemoveCategoriesHandler : IRequestHandler<RemoveCategoriesCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RemoveCategoriesHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveCategoriesCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetFindFirstExpression(k => k.Id == request.Id);
        if (category == null)
        {
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        else
            throw new ApplicationException("Id bilgisine ait kategori bilgisi bulunmamaktadır.");
    }
}

