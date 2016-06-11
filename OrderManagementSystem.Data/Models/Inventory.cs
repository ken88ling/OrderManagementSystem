using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int InitialQTY { get; set; } //input new qty
        public int SafetyLevel { get; set; }
        //public int CurrentQTY { get; set; }
        
        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public Employee Employee { get; set; }

        public SaleLineItem SaleLineItem { get; set; }//just add              

    }
}
