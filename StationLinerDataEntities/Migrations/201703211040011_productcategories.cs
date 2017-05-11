namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParentCategory = c.Long(),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ParentCategory)
                .Index(t => t.ParentCategory);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ParentCategory", "dbo.ProductCategories");
            DropIndex("dbo.ProductCategories", new[] { "ParentCategory" });
            DropTable("dbo.ProductCategories");
        }
    }
}
