namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_id = c.Long(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false),
                        Product_Name = c.String(nullable: false),
                        Product_Description = c.String(),
                        ProductCategoryId = c.Long(nullable: false),
                        ProductRefCode = c.String(),
                        Sellable = c.Boolean(nullable: false),
                        Uom = c.Long(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Product_id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UOMs", t => t.Uom)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.Uom);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Uom", "dbo.UOMs");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "Uom" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropTable("dbo.Products");
        }
    }
}
