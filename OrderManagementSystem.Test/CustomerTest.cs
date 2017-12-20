using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRepository.InMemoryRepository;
using Xunit;
using OrderManagementSystem.Service.Order;

namespace OrderManagementSystem.Test
{

    public class CustomerTest
    {
        [Fact]
        public void CreateCustomer_ShouldCreateValidCustomer()
        {
            var customerRepo = new InMemoryRepository<Customer>();
            var customerService = new CustomerService(customerRepo);


            //Fixture Setup
            var expected = new Customer()
            {
                CustomerCode = "1001",
                FirstName = "Ken",
                MiddleName = "Yew",
                LastName = "Hang",
                DateOfBirth = DateTime.Now,
                Gender = "Male",
                StreetAddress = "5 Kimbery Ave",
                Suburb = "Lane Cove",
                PostCode = "2066",
                State = "Sydney",
                PhoneNo = "4325435345"
            };

            //Exercise the SUT (system under test)
            //customerService.CreateCustomer(expected.CustomerCode, expected.DateOfBirth, expected.FirstName,
            //    expected.LastName, expected.MiddleName, expected.Gender, expected.PhoneNo, expected.StreetAddress,
            //    expected.PostCode, expected.Suburb, expected.State);

            // State Verification
            var actual = customerRepo.AsQueryable().FirstOrDefault();

            Assert.Equal(1, customerRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.Gender, actual.Gender);
            Assert.Equal(expected.StreetAddress, actual.StreetAddress);
            Assert.Equal(expected.Suburb, actual.Suburb);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.PostCode, actual.PostCode);
            Assert.Equal(expected.PhoneNo, actual.PhoneNo);
            Assert.Equal(expected.CustomerCode, actual.CustomerCode);
        }

        [Fact]
        public void UpdateCustomer_ShouldUpdateValidCustomer()
        {
            //Fixture Setup
            var customer = new Customer()
            {
                CustomerCode = "1002",
                FirstName = "Yang",
                MiddleName = "Ling",
                LastName = "Yiao",
                DateOfBirth = DateTime.Now,
                Gender = "Female",
                StreetAddress = "6 Kimbery Ave",
                Suburb = "Chatswood",
                PostCode = "2065",
                State = "Sydney",
                PhoneNo = "4325345435345"
            };

            var customerRepo = new InMemoryRepository<Customer>();
            customerRepo.Add(customer);

            var customerService = new CustomerService(customerRepo);
            
            var expected = new Customer()
            {
                CustomerCode = "1001",
                FirstName = "Ken",
                MiddleName = "Yew",
                LastName = "Hang",
                DateOfBirth = DateTime.Now,
                Gender = "Male",
                StreetAddress = "5 Kimbery Ave",
                Suburb = "Lane Cove",
                PostCode = "2066",
                State = "Sydney",
                PhoneNo = "4325435345"
            };

            //Exercise the SUT (system under test)
            customerService.UpdateCustomer(customer.Id, expected.DateOfBirth, expected.FirstName, expected.LastName,
                expected.MiddleName, expected.Gender, expected.PhoneNo, expected.StreetAddress, expected.PostCode,
                expected.Suburb, expected.State);

            // State Verification
            var actual = customerRepo.Get(customer.Id);

            Assert.Equal(1, customerRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.Gender, actual.Gender);
            Assert.Equal(expected.StreetAddress, actual.StreetAddress);
            Assert.Equal(expected.Suburb, actual.Suburb);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.PostCode, actual.PostCode);
            Assert.Equal(expected.PhoneNo, actual.PhoneNo);
            Assert.Equal(expected.CustomerCode, actual.CustomerCode);

        }


    }
}