using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class Sale
    {
        //it is order 

        public int SaleId { get; set; }
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime? PurchaseDate { get; set; }

        
        public Customer Customer { get; set; }
        public ICollection<SaleLineItem> SaleLineItemlist { get; set; }
    }
}
