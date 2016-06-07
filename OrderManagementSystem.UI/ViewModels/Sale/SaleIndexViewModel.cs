using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.UI.ViewModels.Sale
{
    public class SaleIndexViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}