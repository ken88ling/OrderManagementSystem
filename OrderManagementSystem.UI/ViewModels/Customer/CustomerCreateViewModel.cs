using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.UI.ViewModels.Customer
{
    public class CustomerCreateViewModel
    {

        [Display(Name = "User Name")]
        public string UserName { get; set; }        
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }

    }
}