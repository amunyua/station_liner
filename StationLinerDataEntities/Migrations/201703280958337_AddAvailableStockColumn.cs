namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableStockColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarehouseProducts", "AvailableStock", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarehouseProducts", "AvailableStock");
        }
    }
}
