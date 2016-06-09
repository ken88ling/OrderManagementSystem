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
    public class ProductTest
    {
        [Fact]
        public void CreateProduct_ShouldCreateValidProduct()
        {
            var productRepo = new InMemoryRepository<Product>();
            var productService = new ProductService(productRepo);


            //Fixture Setup
            var expected = new Product()
            {
               CategoryId = 1,
               ProductName = "Product test",
               Description = "this is description",
               Cost = 12,
               Price = 15,
               VendorId = 1
            };

            //Exercise the SUT (system under test)

            productService.CreateProduct(expected.CategoryId, expected.ProductName, expected.Description, expected.Cost.Value,
                expected.Price.Value, expected.VendorId);
            
            // State Verification
            var actual = productRepo.AsQueryable().FirstOrDefault();

            Assert.Equal(1, productRepo.Count());
            Assert.Equal(expected.CategoryId, actual.CategoryId);
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Cost, actual.Cost);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.VendorId, actual.VendorId);
        }

        [Fact]
        public void UpdateProduct_ShouldUpdateValidProduct()
        {
            //Fixture Setup
            var product = new Product()
            {
                CategoryId = 1,
                ProductName = "Product test",
                Description = "this is description",
                Cost = 12,
                Price = 15,
                VendorId = 1
            };

            var productRepo = new InMemoryRepository<Product>();
            productRepo.Add(product);

            var productservice = new ProductService(productRepo);

            var expected = new Product()
            {
                CategoryId = 1,
                ProductName = "Product test",
                Description = "this is description",
                Cost = 12,
                Price = 15,
                VendorId = 1

            };

            //Exercise the SUT (system under test)
            productservice.UpdateProduct(product.Id, expected.CategoryId, expected.ProductName, expected.Description,
                expected.Price.Value, expected.VendorId);

            // State Verification
            var actual = productRepo.Get(product.Id);

            Assert.Equal(1, productRepo.Count());
            Assert.Equal(expected.CategoryId, actual.CategoryId);
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Cost, actual.Cost);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.VendorId, actual.VendorId);
        }
    }
}
