using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Service.Order
{
    public class ProductService
    {
        private readonly OrderDbContext _context;
        public ProductService(OrderDbContext context)
        {
            _context = context;
        }

        public Product CreateProduct(int categoryId, string productName, string description, decimal price, int vendorId)
        {
            var product = new Product()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Description = description,
                Price = price,
                VendorId = vendorId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product UpdateProduct(int productId, int categoryId, string productName, string description, decimal price, int vendorId)
        {
            var product = _context.Products.Find(productId);
            product.CategoryId = categoryId;
            product.ProductName = productName;
            product.Description = description;
            product.Price = price;
            product.VendorId = vendorId;

            return product;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
