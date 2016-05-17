using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    [Table("Customer")]
    public class Customer : Person
    {
        //public int CustomerId { get; set; }

        public Region Region { get; set; }
    }
}
