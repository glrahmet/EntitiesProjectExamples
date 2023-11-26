using DataAccess.Context;
using DataAccess.Repositories;
using EntitiesProject.Models;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext applicationContext) : base(applicationContext)
    {
    }
}

 