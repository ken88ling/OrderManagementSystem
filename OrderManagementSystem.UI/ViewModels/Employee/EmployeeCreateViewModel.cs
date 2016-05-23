using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.UI.ViewModels.Employee
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Employee Number")]
        public string EmployeeNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Hire")]       
        public DateTime? HireDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]       
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
    }
}