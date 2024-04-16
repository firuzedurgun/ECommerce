using ECommerce.Data.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Entities.Common
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
