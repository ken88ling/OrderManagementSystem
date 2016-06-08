using OrderManagementSystem.UI.ViewModels.SaleLineItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagementSystem.UI.ViewModels.Sale
{
    public class SaleCreateViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public SelectList CustomerSelectList { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime PurchaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime PaymentDate { get; set; }

        public int Productindex { get; set; }
        public string ProductName { get; set; }

        public string ProductFullDetail { get; set; }

        public SelectList ProductSelectList { get; set; }
        
        public int Quantity { get; set; }

        public List<Data.Models.Sale> Sales { get; set; }
        public List<Data.Models.Product> Products { get; set; }
        public List<SaleLineItemCreateViewModel> SaleLineItems { get; set; }
    }
}