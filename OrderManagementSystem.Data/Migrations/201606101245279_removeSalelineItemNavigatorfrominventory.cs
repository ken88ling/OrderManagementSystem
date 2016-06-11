namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSalelineItemNavigatorfrominventory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" }, "dbo.SaleLineItem");
            DropIndex("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" });
            DropColumn("dbo.Inventory", "SaleLineItem_SaleId");
            DropColumn("dbo.Inventory", "SaleLineItem_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "SaleLineItem_ProductId", c => c.Int());
            AddColumn("dbo.Inventory", "SaleLineItem_SaleId", c => c.Int());
            CreateIndex("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" });
            AddForeignKey("dbo.Inventory", new[] { "SaleLineItem_SaleId", "SaleLineItem_ProductId" }, "dbo.SaleLineItem", new[] { "SaleId", "ProductId" });
        }
    }
}
