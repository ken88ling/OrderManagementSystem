namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.VendorId)
                .Index(t => t.CategoryId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.SaleLineItem",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Short(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        PaymentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Person", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
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
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.String(),
                        InitialQTY = c.Int(nullable: false),
                        SafetyLevel = c.Int(nullable: false),
                        CurrentQTY = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Product_Id = c.Int(),
                        Vendor_VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Person", t => t.Employee_Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.Vendor", t => t.Vendor_VendorId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Vendor_VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "Vendor_VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Inventory", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Inventory", "Employee_Id", "dbo.Person");
            DropForeignKey("dbo.Cart", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.SaleLineItem", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sale", "CustomerId", "dbo.Person");
            DropForeignKey("dbo.SaleLineItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Inventory", new[] { "Vendor_VendorId" });
            DropIndex("dbo.Inventory", new[] { "Product_Id" });
            DropIndex("dbo.Inventory", new[] { "Employee_Id" });
            DropIndex("dbo.Sale", new[] { "CustomerId" });
            DropIndex("dbo.SaleLineItem", new[] { "ProductId" });
            DropIndex("dbo.SaleLineItem", new[] { "SaleId" });
            DropIndex("dbo.Product", new[] { "VendorId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "Product_Id" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Vendor");
            DropTable("dbo.Person");
            DropTable("dbo.Sale");
            DropTable("dbo.SaleLineItem");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Cart");
        }
    }
}
