namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OrderManagementSystem.Data.Models;

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

            context.WareHouses.AddOrUpdate(
                w => w.Name,
                new WareHouse() { Name = "Sydney WareHouse" },
                new WareHouse() { Name = "Melbourne WareHouse" });

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                new Category() { Description = "Clother" },
                new Category() { Description = "Electronics" },
                new Category() { Description = "Lights" },
                new Category() { Description = "Bags" });
        }
    }
}
