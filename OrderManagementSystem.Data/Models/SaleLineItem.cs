using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class SaleLineItem
    {
        public int? SaleId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
 