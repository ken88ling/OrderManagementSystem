using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class Employee : Person
    {
        // not need to Id because use person id already, 
        //it will create discriminator automatics

        public string EmployeeNo { get; set; }
        public DateTime? HireDate { get; set; }

    }
}
