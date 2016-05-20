﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    //[Table("Customer")]
    public class Customer : Person
    {
        // no need to put Id, because get from person
        //public int CustomerNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
