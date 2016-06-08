using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.UI.ViewModels.SaleLineItem
{
    public class SaleLineItemCreateViewModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }

        public decimal Total
        {
            get { return QTY*Price; }
        }

    }
}