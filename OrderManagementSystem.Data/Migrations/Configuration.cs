using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderManagementSystem.Data.Models.OrderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OrderManagementSystem.Data.Models.OrderDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (context.Customers.Any())
            {
                return;;
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    var customer = new Customer()
                    {
                        CustomerCode = "Code " + i,
                        DateOfBirth = DateTime.Now.Date.AddDays(-i),
                        FirstName = "First Name " + i,
                        LastName = "Last Name" + i,
                        Gender = i % 2 == 0 ? "Male" : "Female",
                        MiddleName = "Middle Name " + i,
                        PhoneNo = "Phone " + i,
                        PostCode = "Post code " + i,
                        State = "State " + i,
                        StreetAddress = "Street Address " + i,
                        Suburb = "Suburb " + i
                    };

                }
            }
        }
    }
}
