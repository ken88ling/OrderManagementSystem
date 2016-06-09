using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.UI.ViewModels.Inventories
{
    public class InventoryCreateVM
    {
        public int InventoryId { get; set; }
        public int InitialQTY { get; set; }
        public int SafetyLevel { get; set; }
        public int CurrentQuantity { get; set; }

        //public int CurrentQuantity
        //{
        //    get
        //    {
        //        return InitialQTY 
        //    }
        //}


        public string ProductId { get; set; }
        public SelectList ProductSelectList { get; set; }
        
    }
}