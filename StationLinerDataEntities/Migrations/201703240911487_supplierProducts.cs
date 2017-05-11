namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierProducts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        SupplierId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierProducts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SupplierProducts", new[] { "ProductId" });
            DropIndex("dbo.SupplierProducts", new[] { "SupplierId" });
            DropTable("dbo.SupplierProducts");
        }
    }
}
