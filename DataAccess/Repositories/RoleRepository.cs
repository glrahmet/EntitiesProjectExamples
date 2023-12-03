using DataAccess.Context;
using EntitiesProject.Models;
using EntitiesProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal sealed class RoleRepository : Repository<AppRole>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
