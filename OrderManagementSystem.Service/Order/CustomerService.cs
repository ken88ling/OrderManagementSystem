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

        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> context)
        {
            _customerRepository = context;
        }

        

        public Customer CreateCustomer(Customer model)
        {
            var customer = new Customer()
            {
                CustomerCode = model.CustomerCode,
                DateOfBirth =model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Gender = model.Gender,
                PhoneNo = model.PhoneNo,
                StreetAddress = model.StreetAddress,
                PostCode = model.PostCode,
                Suburb = model.Suburb,
                State = model.State

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
