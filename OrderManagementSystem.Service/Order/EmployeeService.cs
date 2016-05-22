using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Service.Order
{
    public class EmployeeService
    {
        private OrderDbContext _context;
        public EmployeeService(OrderDbContext context)
        {
            _context = context;
        }


        public Employee CreateEmployee(string employeeNo,  DateTime? hireDate, DateTime? dateOfBirth, string firstName = null, string lastName = null, string middleName = null,
            string gender = null, string phoneNo = null, string streetAddress = null, string postCode = null, string suburb = null, string state = null)
        {
            var employee = new Employee()
            {
                EmployeeNo = employeeNo,
                HireDate = hireDate,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                PhoneNo = phoneNo,
                StreetAddress = streetAddress,
                Suburb = suburb,
                State = state,
                PostCode = postCode
            };

            if(employee == null)
            {
                throw new InvalidOperationException("No employee with provided id was found");
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        //public Employee UpdateEmployee()



    }
}
