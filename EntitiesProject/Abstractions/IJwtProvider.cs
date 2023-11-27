using EntitiesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesProject.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
