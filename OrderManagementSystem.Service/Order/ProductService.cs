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
        private OrderDbContext _context;
        public ProductService(OrderDbContext context)
        {
            _context = context;
        }

        //public Product CreateProduct(int categoryId, string productName,string description, decimal price, string vendorId )
        //{
            
        //}
    }
}
