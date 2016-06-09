using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRepository.Repository;

namespace OrderManagementSystem.Service.Order
{
    public class CustomerService
    {
        //private OrderDbContext _context;

        //public CustomerService(OrderDbContext context)
        //{
        //    _context = context;
        //}

        private IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> context)
        {
            _customerRepository = context;
        }
        //public Customer CreateUser(string customerCode, string password)
        //{
        //    var customer = new Customer()
        //    {
        //        //CustomerCode = customerCode,
        //        //Password = password
        //    };

        //    var result = _customerRepository.Customers.FirstOrDefault(
        //        c => c.CustomerCode == customerCode);
        //    if (result != null)
        //    {
        //        throw new InvalidOperationException(
        //            String.Format("{0} already exists!", customerCode));
        //    }
        //    _customerRepository.Add(customer);
        //    //_context.SaveChanges();
        //    return customer;
        //}
        //public void InsertCustomer(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //}
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
            _customerRepository.Add(customer);
            return customer;
        }

        public Customer UpdateCustomer(int customerId, DateTime? dateofBirth, string firstName=null, string lastName=null, string middleName=null,
            string gender=null, string phoneNo=null, string streetAddress = null, string postCode = null, string suburb = null, string state = null)
        {
            var customer = _customerRepository.Get(customerId);

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

            _customerRepository.Update(customer);
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.Get(id);
            if(customer == null)
            {
                throw new InvalidOperationException("No UserName with the provided id was found!");
            }

            _customerRepository.Delete(customer);
        }
    }
}
