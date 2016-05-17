using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class SaleLedger
    {
        // Sale Ledger inquiry contain 
        //OrderNo,OrderType, OrderCo,LineNumber,SoldTo,Name,
        //Qty,QtyShipped,AmountOrdered,AmountShipped,Currency
        public int SaleLedgerId { get; set; }

        public string SaleId { get; set; }
        public Sale Sale { get; set; }
        public virtual Product Product { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}
