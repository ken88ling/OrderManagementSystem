using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrderManagementSystem.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        
        public string Description { get; set; }

        public decimal? Cost { get; set; }

        public decimal? Price { get; set; }
        
        public int VendorId { get; set; }

        public int CurrentQTY { get; set; }



        
        //supplier
        public Vendor Vendor { get; set; }
        public Category Category { get; set; }

        //navigator
        public ICollection<SaleLineItem> SaleLineItems { get; set; }


        public Product()
        {
            SaleLineItems = new List<SaleLineItem>();
        }
    }
}
