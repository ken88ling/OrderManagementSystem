using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public enum Gender
    {
        Male,
        Female,
        [Display(Name ="No Specifed")]
        NoSpecifed
    }
}
