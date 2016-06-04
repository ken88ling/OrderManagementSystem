using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagementSystem.UI.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        
        public string CategoryName { get; set; }
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Vendor Name")]
        public string VendorName { get; set; }

        
        
    }
}