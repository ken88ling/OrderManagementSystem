namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "SaleLineItem_SaleId", c => c.Int());
            AddColumn("dbo.Inventory", "SaleLineItem_ProductId", c => c.Int());
            CreateIndex("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" });
            AddForeignKey("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" }, "dbo.SaleLineItem", new[] { "SaleId", "ProductId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" }, "dbo.SaleLineItem");
            DropIndex("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" });
            DropColumn("dbo.Inventory", "SaleLineItem_ProductId");
            DropColumn("dbo.Inventory", "SaleLineItem_SaleId");
        }
    }
}
