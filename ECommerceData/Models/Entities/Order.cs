using ECommerce.Data.Models.Entities.Common;
using ECommerce.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Entities
{
    public class Order:BaseEntity
    {
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string UserName { get; set; }
        public string AdressTitle { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Neighbourhood { get; set; }
        public string PostalCode{ get; set; }
    }
}
