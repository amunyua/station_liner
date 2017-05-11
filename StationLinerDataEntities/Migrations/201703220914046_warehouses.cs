namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warehouses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WarehouseName = c.String(nullable: false),
                        WarehouseLocation = c.String(),
                        WarehouseType = c.Long(nullable: false),
                        MaximumCapacity = c.Double(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WarehouseTypes", t => t.WarehouseType, cascadeDelete: true)
                .Index(t => t.WarehouseType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warehouses", "WarehouseType", "dbo.WarehouseTypes");
            DropIndex("dbo.Warehouses", new[] { "WarehouseType" });
            DropTable("dbo.Warehouses");
        }
    }
}
