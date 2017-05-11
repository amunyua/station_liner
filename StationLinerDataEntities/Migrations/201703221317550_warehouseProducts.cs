namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warehouseProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarehouseProducts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReorderLevel = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        WarehouseId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseProducts", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.WarehouseProducts", new[] { "ProductId" });
            DropIndex("dbo.WarehouseProducts", new[] { "WarehouseId" });
            DropTable("dbo.WarehouseProducts");
        }
    }
}
