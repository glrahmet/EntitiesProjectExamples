using EntitiesProject.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesProject.Models
{
    public sealed class Category : Entity
    { 
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
