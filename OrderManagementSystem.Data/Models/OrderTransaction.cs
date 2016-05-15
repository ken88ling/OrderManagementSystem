using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class OrderTransaction
    {
        public int OrderTransactionId { get; set; }
        public string Name { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}
