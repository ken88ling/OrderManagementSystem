namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CurrentQTY", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CurrentQTY");
        }
    }
}
