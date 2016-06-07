namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "VendorId", "dbo.Vendor");
            DropIndex("dbo.Product", new[] { "VendorId" });
            AlterColumn("dbo.Product", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "VendorId");
            AddForeignKey("dbo.Product", "VendorId", "dbo.Vendor", "VendorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "VendorId", "dbo.Vendor");
            DropIndex("dbo.Product", new[] { "VendorId" });
            AlterColumn("dbo.Product", "VendorId", c => c.Int());
            CreateIndex("dbo.Product", "VendorId");
            AddForeignKey("dbo.Product", "VendorId", "dbo.Vendor", "VendorId");
        }
    }
}
