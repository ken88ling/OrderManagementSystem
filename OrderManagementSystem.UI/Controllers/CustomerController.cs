using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Service.Order;

namespace OrderManagementSystem.UI.Controllers
{
    public class CustomerController : Controller
    {
        private OrderDbContext _context;
        private CustomerService _customerService;

        public CustomerController()
        {
            _context = new OrderDbContext();
            _customerService = new CustomerService(_context);
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }


    }
}