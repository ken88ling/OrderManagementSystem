namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinventoryproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "WareHouseLocation_WareHouseId", "dbo.WareHouse");
            DropIndex("dbo.Inventory", new[] { "WareHouseLocation_WareHouseId" });
            AddColumn("dbo.Inventory", "ProductId", c => c.String());
            AddColumn("dbo.Inventory", "InitialQTY", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "CurrentQTY", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "Product_ProductId", c => c.Int());
            AddColumn("dbo.Inventory", "Vendor_VendorId", c => c.Int());
            AddColumn("dbo.Vendor", "Address", c => c.String());
            AddColumn("dbo.Vendor", "ContactPerson", c => c.String());
            AddColumn("dbo.Vendor", "Email", c => c.String());
            CreateIndex("dbo.Inventory", "Product_ProductId");
            CreateIndex("dbo.Inventory", "Vendor_VendorId");
            AddForeignKey("dbo.Inventory", "Product_ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.Inventory", "Vendor_VendorId", "dbo.Vendor", "VendorId");
            DropColumn("dbo.Inventory", "PartId");
            DropColumn("dbo.Inventory", "Initial_QTY");
            DropColumn("dbo.Inventory", "WareHouseLocation_WareHouseId");
            DropTable("dbo.WareHouse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WareHouse",
                c => new
                    {
                        WareHouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WareHouseId);
            
            AddColumn("dbo.Inventory", "WareHouseLocation_WareHouseId", c => c.Int());
            AddColumn("dbo.Inventory", "Initial_QTY", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "PartId", c => c.String());
            DropForeignKey("dbo.Inventory", "Vendor_VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Inventory", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Inventory", new[] { "Vendor_VendorId" });
            DropIndex("dbo.Inventory", new[] { "Product_ProductId" });
            DropColumn("dbo.Vendor", "Email");
            DropColumn("dbo.Vendor", "ContactPerson");
            DropColumn("dbo.Vendor", "Address");
            DropColumn("dbo.Inventory", "Vendor_VendorId");
            DropColumn("dbo.Inventory", "Product_ProductId");
            DropColumn("dbo.Inventory", "CurrentQTY");
            DropColumn("dbo.Inventory", "InitialQTY");
            DropColumn("dbo.Inventory", "ProductId");
            CreateIndex("dbo.Inventory", "WareHouseLocation_WareHouseId");
            AddForeignKey("dbo.Inventory", "WareHouseLocation_WareHouseId", "dbo.WareHouse", "WareHouseId");
        }
    }
}
