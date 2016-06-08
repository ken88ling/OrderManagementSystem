namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeshorttoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SaleLineItem", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleLineItem", "Quantity", c => c.Short(nullable: false));
        }
    }
}
