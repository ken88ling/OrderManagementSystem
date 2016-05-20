using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Service.Order
{
    public class CustomerService
    {
        private OrderDbContext _context;
        public CustomerService(OrderDbContext context)
        {
            _context = context;
        }

        public Customer CreateUser(string userName, string password)
        {
            var customer = new Customer()
            {
                UserName = userName,
                Password = password
            };

            var result = _context.Customers.FirstOrDefault(
                c => c.UserName == userName);
            if(result != null)
            {
                throw new InvalidOperationException(
                    String.Format("{0} already exists!", userName));
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer CreateCustomer(string userName,string Password, DateTime? dateofBirth, string firstName = null, string lastName = null, string middleName = null,
            string gender = null, string phoneNo = null, string streetAddress = null,string postCode=null, string suburb = null, string state =null)
        {
            var customer = new Customer
            {
                UserName = userName,
                Password = Password,
                DateOfBirth = dateofBirth,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Gender = gender,
                PhoneNo = phoneNo,
                StreetAddress = streetAddress,
                Postcode = postCode,
                Suburb = suburb,
                State = state
            };

            if(customer == null)
            {
                throw new InvalidOperationException("No customer with provided id was found");
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(int customerId, DateTime? dateofBirth, string firstName=null, string lastName=null, string middleName=null,
            string gender=null, string phoneNo=null, string streetAddress = null, string postCode = null, string suburb = null, string state = null)
        {
            var customer = _context.Customers.FirstOrDefault(b => b.Id == customerId);

            if (customer == null)
            {
                throw new InvalidOperationException("No User with the provided id was found");
            }

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.MiddleName = middleName;
            customer.DateOfBirth = dateofBirth;
            customer.Gender = gender;
            customer.PhoneNo = phoneNo;
            customer.StreetAddress = streetAddress;
            customer.Postcode = postCode;
            customer.Suburb = suburb;
            customer.State = state;

            _context.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer == null)
            {
                throw new InvalidOperationException("No UserName with the provided id was found!");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
