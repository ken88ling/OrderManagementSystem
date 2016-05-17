namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region_RegionId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Region", t => t.Region_RegionId)
                .Index(t => t.Region_RegionId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_EmployeeId = c.Int(),
                        StoreLocation_WareHouseId = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.WareHouse", t => t.StoreLocation_WareHouseId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.StoreLocation_WareHouseId);
            
            CreateTable(
                "dbo.WareHouse",
                c => new
                    {
                        WareHouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WareHouseId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vendor_VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Vendor", t => t.Vendor_VendorId)
                .Index(t => t.Vendor_VendorId);
            
            CreateTable(
                "dbo.SaleLineItem",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Short(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => new { t.SaleId, t.ProductId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.SaleLedger",
                c => new
                    {
                        SaleLedgerId = c.Int(nullable: false, identity: true),
                        SaleId = c.String(),
                        Inventory_InventoryId = c.Int(),
                        Product_ProductId = c.Int(),
                        Sale_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleLedgerId)
                .ForeignKey("dbo.Inventory", t => t.Inventory_InventoryId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .ForeignKey("dbo.Sale", t => t.Sale_SaleId)
                .Index(t => t.Inventory_InventoryId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Sale_SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleLedger", "Sale_SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleLedger", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.SaleLedger", "Inventory_InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Product", "Vendor_VendorId", "dbo.Vendor");
            DropForeignKey("dbo.SaleLineItem", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sale", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.SaleLineItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Inventory", "StoreLocation_WareHouseId", "dbo.WareHouse");
            DropForeignKey("dbo.Inventory", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Customer", "Region_RegionId", "dbo.Region");
            DropIndex("dbo.SaleLedger", new[] { "Sale_SaleId" });
            DropIndex("dbo.SaleLedger", new[] { "Product_ProductId" });
            DropIndex("dbo.SaleLedger", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.Sale", new[] { "CustomerId" });
            DropIndex("dbo.SaleLineItem", new[] { "ProductId" });
            DropIndex("dbo.SaleLineItem", new[] { "SaleId" });
            DropIndex("dbo.Product", new[] { "Vendor_VendorId" });
            DropIndex("dbo.Inventory", new[] { "StoreLocation_WareHouseId" });
            DropIndex("dbo.Inventory", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Customer", new[] { "Region_RegionId" });
            DropTable("dbo.SaleLedger");
            DropTable("dbo.Vendor");
            DropTable("dbo.Sale");
            DropTable("dbo.SaleLineItem");
            DropTable("dbo.Product");
            DropTable("dbo.WareHouse");
            DropTable("dbo.Inventory");
            DropTable("dbo.Employee");
            DropTable("dbo.Region");
            DropTable("dbo.Customer");
        }
    }
}
