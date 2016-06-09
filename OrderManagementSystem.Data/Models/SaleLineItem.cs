using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class SaleLineItem
    {
        
        [Key, Column(Order = 1)]
        public int? SaleId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        //navigator
        public Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
 