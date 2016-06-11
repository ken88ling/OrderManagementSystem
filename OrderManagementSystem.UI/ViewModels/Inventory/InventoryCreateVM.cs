using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;


namespace OrderManagementSystem.UI.ViewModels.Inventory
{

    public class InventoryCreateVM
    {
        //OrderDbContext db = new OrderDbContext();
        public int InventoryId { get; set; }
        public int InitialQTY { get; set; }
        public int SafetyLevel { get; set; }
        public int CurrentQuantity { get; set; }

        //public int CurrentQuantity
        //{
        //    get
        //    {
        //        return db.Products.
        //    }
        //    set
        //    {
        //        Data.Models.SaleLineItem item = new Data.Models.SaleLineItem();
        //        CurrentQuantity = InitialQTY - item.Quantity;
        //    }
        //}


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public SelectList ProductSelectList { get; set; }
        
    }
}