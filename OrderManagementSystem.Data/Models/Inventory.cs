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
        public string Name { get; set; }

        public virtual StoreLocation StoreLocation { get; set; }
        public virtual Employee Employee { get; set; }        

    }
}
