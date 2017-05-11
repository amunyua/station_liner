namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.Long(nullable: false),
                        WarehouseId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: true),
                        Quantity = c.Double(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: false)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: false)
                .Index(t => t.TransactionId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDetails", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.TransactionDetails", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.TransactionDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.TransactionDetails", new[] { "ProductId" });
            DropIndex("dbo.TransactionDetails", new[] { "WarehouseId" });
            DropIndex("dbo.TransactionDetails", new[] { "TransactionId" });
            DropTable("dbo.TransactionDetails");
        }
    }
}
