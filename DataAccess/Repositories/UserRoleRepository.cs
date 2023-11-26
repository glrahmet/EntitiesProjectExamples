using DataAccess.Context;
using DataAccess.Repositories;
using EntitiesProject.Models;

internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationContext applicationContext) : base(applicationContext)
    {
    }
}

 