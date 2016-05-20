using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50,ErrorMessage ="Last Name can't be longer than 50 characters")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name ="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
