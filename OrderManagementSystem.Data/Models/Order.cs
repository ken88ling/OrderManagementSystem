using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
