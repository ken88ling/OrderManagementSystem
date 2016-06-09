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
        //public virtual ICollection<Data.Models.Sale> SaleList { get; set; }
        //public virtual ICollection<Data.Models.SaleLineItem> SaleLineItemList { get; set; }
        public IGrouping<string, Data.Models.Product> Products;
    }
}