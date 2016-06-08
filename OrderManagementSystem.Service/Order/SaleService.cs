using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Service.Order
{
    public class SaleService
    {
        private OrderDbContext _context;

        public SaleService(OrderDbContext context)
        {
            _context = context;
        }

        public Sale CreateSale(int customerId, DateTime paymentTime, List<SaleLineItem> saleLineItems )
        {
            var sale = new Sale();
            sale.CustomerId = customerId;
            sale.PurchaseDate = DateTime.Now;
            sale.PaymentDate = paymentTime;
            sale.SaleLineItems = saleLineItems;
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return sale;
        }

        //public Sale CreateSale(int customerId, DateTime paymentTime, int productId, int quantity)
        //{
        //    var sale = new Sale();
        //    sale.CustomerId = customerId;
        //    sale.PurchaseDate = DateTime.Now;
        //    sale.PaymentDate = paymentTime;
        //    sale.SaleLineItems = 
        //    //var salelineItem = new SaleLineItem();
        //    //salelineItem.ProductId = productId;
        //    //salelineItem.Quantity = quantity;
        //    //salelineItem.UnitPrice = _context.Products.Find(productId).Price.Value;
        //    //sale.SaleLineItems.Add(salelineItem);

        //    _context.Sales.Add(sale);
        //    _context.SaveChanges();
        //    return sale;
        //}

        public Sale UpdateSale(int id, int customerId, DateTime? purchaseDate, DateTime? paymentDate)
        {
            var sale = _context.Sales.Find(id);
            if (sale == null)
            {
                throw new InvalidOperationException("No Sale with provided id was found!");
            }

            sale.CustomerId = customerId;
            sale.PurchaseDate = purchaseDate;
            sale.PaymentDate = paymentDate;

            _context.SaveChanges();
            return sale;
        }

        public Sale DeleteSale(int Id)
        {
            var sale = _context.Sales.Find(Id);
            if (sale == null)
            {
                throw new InvalidOperationException("No Sale with provided id was found!");
            }
            _context.Sales.Remove(sale);
            _context.SaveChanges();
            return sale;
        }

    }
}
