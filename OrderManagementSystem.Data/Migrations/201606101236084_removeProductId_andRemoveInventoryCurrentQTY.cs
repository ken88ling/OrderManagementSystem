namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProductId_andRemoveInventoryCurrentQTY : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "CurrentQTY");
            DropColumn("dbo.Inventory", "CurrentQTY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "CurrentQTY", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "CurrentQTY", c => c.Int());
        }
    }
}
