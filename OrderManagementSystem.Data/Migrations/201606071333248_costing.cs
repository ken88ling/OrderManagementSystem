namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class costing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Product", "Cost");
        }
    }
}
