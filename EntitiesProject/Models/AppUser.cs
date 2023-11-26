using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesProject.Models
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
