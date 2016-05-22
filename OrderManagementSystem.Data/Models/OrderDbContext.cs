using OrderManagementSystem.Data.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data.Models
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleLineItem> SaleLineItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        //public DbSet<Region> Regions { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new SaleLineItemMap());

            //modelBuilder.Entity<Customer>()
            //    .Map(map =>
            //        {
            //            map.Properties(p => new
            //            {
            //                p.Id,
            //                p.FirstName,
            //                p.LastName,
            //                p.MiddleName,
            //                p.DateOfBirth,
            //                p.Gender,
            //                p.PhoneNo,
            //                p.StreetAddress,
            //                p.Suburb,
            //                p.State,
            //                p.PostCode
            //            });
            //            map.ToTable("Person");
            //        })
            //        .Map(map =>
            //        {
            //            map.Properties(p => new
            //            {
            //                p.UserName,
            //                p.Password
            //            });
            //            map.ToTable("Customer");
            //        });


        }
    }
}
