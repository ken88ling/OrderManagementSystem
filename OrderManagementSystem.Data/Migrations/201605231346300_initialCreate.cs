namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.String(),
                        PhoneNo = c.String(),
                        StreetAddress = c.String(),
                        Suburb = c.String(),
                        State = c.String(),
                        PostCode = c.String(),
                        CustomerCode = c.String(),
                        EmployeeNo = c.String(),
                        HireDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        PartId = c.String(),
                        Initial_QTY = c.Int(nullable: false),
                        SafetyLevel = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        WareHouseLocation_WareHouseId = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Person", t => t.Employee_Id)
                .ForeignKey("dbo.WareHouse", t => t.WareHouseLocation_WareHouseId)
                .Index(t => t.Employee_Id)
                .Index(t => t.WareHouseLocation_WareHouseId);
            
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
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.Vendor_VendorId)
                .Index(t => t.CategoryId)
                .Index(t => t.Vendor_VendorId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Person", t => t.CustomerId, cascadeDelete: true)
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
                "dbo.SaleProduct",
                c => new
                    {
                        Sale_SaleId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sale_SaleId, t.Product_ProductId })
                .ForeignKey("dbo.Sale", t => t.Sale_SaleId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Sale_SaleId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleLineItem", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleLineItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Vendor_VendorId", "dbo.Vendor");
            DropForeignKey("dbo.SaleProduct", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.SaleProduct", "Sale_SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sale", "CustomerId", "dbo.Person");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Inventory", "WareHouseLocation_WareHouseId", "dbo.WareHouse");
            DropForeignKey("dbo.Inventory", "Employee_Id", "dbo.Person");
            DropIndex("dbo.SaleProduct", new[] { "Product_ProductId" });
            DropIndex("dbo.SaleProduct", new[] { "Sale_SaleId" });
            DropIndex("dbo.SaleLineItem", new[] { "ProductId" });
            DropIndex("dbo.SaleLineItem", new[] { "SaleId" });
            DropIndex("dbo.Sale", new[] { "CustomerId" });
            DropIndex("dbo.Product", new[] { "Vendor_VendorId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Inventory", new[] { "WareHouseLocation_WareHouseId" });
            DropIndex("dbo.Inventory", new[] { "Employee_Id" });
            DropTable("dbo.SaleProduct");
            DropTable("dbo.SaleLineItem");
            DropTable("dbo.Vendor");
            DropTable("dbo.Sale");
            DropTable("dbo.Product");
            DropTable("dbo.WareHouse");
            DropTable("dbo.Inventory");
            DropTable("dbo.Person");
            DropTable("dbo.Category");
        }
    }
}
