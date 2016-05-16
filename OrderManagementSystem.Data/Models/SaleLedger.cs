using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class SaleLedger
    {
        public int SaleLedgerId { get; set; }
        public string SaleId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}
