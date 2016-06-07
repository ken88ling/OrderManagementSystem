using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagementSystem.UI.ViewModels.Sale
{
    public class SaleEditViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public SelectList Customers { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime? PaymentDate { get; set; }
    }
}