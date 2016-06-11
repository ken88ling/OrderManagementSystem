namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CurrentQTY", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CurrentQTY");
        }
    }
}
