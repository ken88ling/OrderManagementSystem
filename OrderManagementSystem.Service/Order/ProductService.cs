using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Data.Models;
using SharpRepository.Repository;

namespace OrderManagementSystem.Service.Order
{
    public class ProductService
    {
        //private readonly OrderDbContext _context;
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> context)
        {
            _productRepository = context;
        }

        public Product CreateProduct(int categoryId, string productName, string description, decimal cost,decimal price, int vendorId)
        {
            var product = new Product()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Description = description,
                Cost = cost,
                Price = price,
                VendorId = vendorId
            };

            _productRepository.Add(product);
            //_context.SaveChanges();

            return product;
        }

        public Product UpdateProduct(int productId, int categoryId, string productName, string description, decimal price, int vendorId)
        {
            var product = _productRepository.Get(productId);
            product.CategoryId = categoryId;
            product.ProductName = productName;
            product.Description = description;
            product.Price = price;
            product.VendorId = vendorId;

            return product;
        }

        public void DeleteProduct(int productId)
        {
            var product = _productRepository.Get(productId);
            _productRepository.Delete(product);
            //_context.SaveChanges();
        }
    }
}
