namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecolumncustomerscustomerNo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "CustomerNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "CustomerNo", c => c.Int());
        }
    }
}
