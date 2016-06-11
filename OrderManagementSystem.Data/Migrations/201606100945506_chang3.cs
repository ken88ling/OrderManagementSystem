namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "Product_Id", "dbo.Product");
            DropIndex("dbo.Inventory", new[] { "Product_Id" });
            DropColumn("dbo.Inventory", "ProductId");
            RenameColumn(table: "dbo.Inventory", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.Inventory", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventory", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventory", "ProductId");
            AddForeignKey("dbo.Inventory", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Product");
            DropIndex("dbo.Inventory", new[] { "ProductId" });
            AlterColumn("dbo.Inventory", "ProductId", c => c.Int());
            AlterColumn("dbo.Inventory", "ProductId", c => c.String());
            RenameColumn(table: "dbo.Inventory", name: "ProductId", newName: "Product_Id");
            AddColumn("dbo.Inventory", "ProductId", c => c.String());
            CreateIndex("dbo.Inventory", "Product_Id");
            AddForeignKey("dbo.Inventory", "Product_Id", "dbo.Product", "Id");
        }
    }
}
