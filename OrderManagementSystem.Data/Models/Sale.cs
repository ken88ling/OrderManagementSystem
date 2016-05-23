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
        public DateTime? PurchaseDate { get; set; }

        public Customer Customer { get; set; }
        public IList<Product> Products { get; set; }

    }
}

//IList
//IsFixedSize Property
//IsReadOnly Property
//Indexer
//Add Method
//Clear Method
//Contains Method
//Indexof Method
//Insert Method
//Remove Method
//RemoveAt Method