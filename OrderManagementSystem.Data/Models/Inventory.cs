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
        public string ProductId { get; set; }
        public int InitialQTY { get; set; }
        public int SafetyLevel { get; set; }
        public int CurrentQTY { get; set; }
        
        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public Employee Employee { get; set; }        

    }
}
