﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.UI.ViewModels.Employee
{
    public class EmployeeIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]       
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Display(Name = "Address")]
        public string FullAddress { get; set; }        
    }
}