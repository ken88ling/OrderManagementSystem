using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        //public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }


    }
}
