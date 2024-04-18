using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Models.Entities.Common;

namespace ECommerce.Data.Models.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public Category() 
        {
            Products = new List<Product>();
        }
    }
}
