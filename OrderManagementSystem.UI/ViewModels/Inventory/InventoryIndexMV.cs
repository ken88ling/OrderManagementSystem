using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.UI.ViewModels.Inventory
{

    public class InventoryIndexMV
    {
        
        public int InventoryId { get; set; }
        public int InitialQTY { get; set; }
        public int SafetyLevel { get; set; }
        public int CurrentQuantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }


        public List<Data.Models.SaleLineItem> SaleLineItems { get; set; }
        //public List<Data.Models.Product> Products { get; set; }


        public IGrouping<string, Data.Models.Product> Products;
    }
}