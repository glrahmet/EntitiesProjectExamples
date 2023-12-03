using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Authorization
{
    public sealed class RoleFilterAttribute : TypeFilterAttribute
    {
        public RoleFilterAttribute(string role) : base(typeof(RoleAttibute))
        {
            Arguments = new object[] { role };
        }
    }
}
