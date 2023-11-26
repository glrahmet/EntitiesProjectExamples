using EntitiesProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Categories.GetQueryCategories
{
    internal sealed class GetQueryCommandHandler : IRequestHandler<GetCategoriesQueryCommand, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetQueryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetCategoriesQueryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll().OrderBy(p => p.CategoryName).ToListAsync(cancellationToken);
        }
    }
}
