using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class OrderManagementDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderTransaction> OrderTransaction { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Region> Region { get; set; }        
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<StoreLocation> StoreRegion { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
