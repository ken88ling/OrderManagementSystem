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

        public Employee UpdateEmployee(int Id, string employeeNo,  DateTime? hireDate, DateTime? dateOfBirth,
            string firstName = null, string lastName = null, string middleName = null,
            string gender = null, string phoneNo = null, string streetAddress = null, 
            string postCode = null, string suburb = null, string state = null)
        {
            var employee = _context.Employees.Find(Id);
            if(employee == null)
            {
                throw new InvalidOperationException("No employee with provided id was found");                
            }
            employee.EmployeeNo = employeeNo;
            employee.HireDate = hireDate;
            employee.DateOfBirth = dateOfBirth;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.MiddleName = middleName;
            employee.Gender = gender;
            employee.PhoneNo = phoneNo;
            employee.StreetAddress = streetAddress;
            employee.PostCode = postCode;
            employee.Suburb = suburb;
            employee.State = state;

            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if(employee == null)
            {
                throw new InvalidOperationException("No employee with provided id was found");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return employee;
        }
    }
}
