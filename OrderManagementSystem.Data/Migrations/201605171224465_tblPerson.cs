namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeNo", c => c.String());
            DropColumn("dbo.Customer", "CustomerId");
            DropColumn("dbo.Employee", "EmployeeId");
            DropColumn("dbo.Employee", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Name", c => c.String());
            AddColumn("dbo.Employee", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "EmployeeNo");
        }
    }
}
