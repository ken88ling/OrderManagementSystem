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
        public string PartId { get; set; }
        public int Initial_QTY { get; set; }
        public int SafetyLevel { get; set; }
        
        public WareHouse WareHouseLocation { get; set; }
        public Employee Employee { get; set; }        

    }
}
