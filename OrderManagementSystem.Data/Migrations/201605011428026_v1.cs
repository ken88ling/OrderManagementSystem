namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region_RegionId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Regions", t => t.Region_RegionId)
                .Index(t => t.Region_RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_EmployeeId = c.Int(),
                        Region_RegionId = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Regions", t => t.Region_RegionId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Region_RegionId);
            
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        LineItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.LineItemId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Vendor_VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Vendors", t => t.Vendor_VendorId)
                .Index(t => t.Vendor_VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Customer_CustomerId = c.Int(),
                        LineItem_LineItemId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.LineItems", t => t.LineItem_LineItemId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.LineItem_LineItemId);
            
            CreateTable(
                "dbo.OrderTransactions",
                c => new
                    {
                        OrderTransactionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_EmployeeId = c.Int(),
                        Inventory_InventoryId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderTransactionId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Inventories", t => t.Inventory_InventoryId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Inventory_InventoryId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.StoreLocations",
                c => new
                    {
                        StoreLocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StoreLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderTransactions", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderTransactions", "Inventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.OrderTransactions", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "LineItem_LineItemId", "dbo.LineItems");
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.LineItems", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Vendor_VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Inventories", "Region_RegionId", "dbo.Regions");
            DropForeignKey("dbo.Inventories", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Customers", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.OrderTransactions", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderTransactions", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.OrderTransactions", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Orders", new[] { "LineItem_LineItemId" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Products", new[] { "Vendor_VendorId" });
            DropIndex("dbo.LineItems", new[] { "Product_ProductId" });
            DropIndex("dbo.Inventories", new[] { "Region_RegionId" });
            DropIndex("dbo.Inventories", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Customers", new[] { "Region_RegionId" });
            DropTable("dbo.StoreLocations");
            DropTable("dbo.OrderTransactions");
            DropTable("dbo.Orders");
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
            DropTable("dbo.LineItems");
            DropTable("dbo.Inventories");
            DropTable("dbo.Employees");
            DropTable("dbo.Regions");
            DropTable("dbo.Customers");
        }
    }
}
