namespace OrderManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.Inventories", new[] { "Region_RegionId" });
            AddColumn("dbo.Inventories", "StoreLocation_StoreLocationId", c => c.Int());
            CreateIndex("dbo.Inventories", "StoreLocation_StoreLocationId");
            AddForeignKey("dbo.Inventories", "StoreLocation_StoreLocationId", "dbo.StoreLocations", "StoreLocationId");
            DropColumn("dbo.Inventories", "Region_RegionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "Region_RegionId", c => c.Int());
            DropForeignKey("dbo.Inventories", "StoreLocation_StoreLocationId", "dbo.StoreLocations");
            DropIndex("dbo.Inventories", new[] { "StoreLocation_StoreLocationId" });
            DropColumn("dbo.Inventories", "StoreLocation_StoreLocationId");
            CreateIndex("dbo.Inventories", "Region_RegionId");
            AddForeignKey("dbo.Inventories", "Region_RegionId", "dbo.Regions", "RegionId");
        }
    }
}
