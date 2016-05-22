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

        public Customer CreateUser(string customerCode, string password)
        {
            var customer = new Customer()
            {
                //CustomerCode = customerCode,
                //Password = password
            };

            var result = _context.Customers.FirstOrDefault(
                c => c.CustomerCode == customerCode);
            if (result != null)
            {
                throw new InvalidOperationException(
                    String.Format("{0} already exists!", customerCode));
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        public void InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public Customer CreateCustomer(string customerCode, DateTime? dateofBirth, string firstName = null, string lastName = null, string middleName = null,
            string gender = null, string phoneNo = null, string streetAddress = null,string postCode=null, string suburb = null, string state =null)
        {
            var customer = new Customer()
            {
                CustomerCode = customerCode,
                
                DateOfBirth = dateofBirth,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Gender = gender,
                PhoneNo = phoneNo,
                StreetAddress = streetAddress,
                PostCode = postCode,
                Suburb = suburb,
                State = state
                
            };

           
            if (customer == null)
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
            customer.PostCode = postCode;
            customer.Suburb = suburb;
            customer.State = state;

            //customer.FirstName = firstName;
            //customer.LastName = lastName;
            //customer.MiddleName = middleName;

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
