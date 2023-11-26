using DataAccess.Context;
using DataAccess.Repositories;
using EntitiesProject.Models;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
    {
    }
}

 