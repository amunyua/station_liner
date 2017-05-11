namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taxes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTaxCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustCatName = c.String(),
                        CustCatDescription = c.String(),
                        ModifiedBy = c.Long(),
                        DateCreated = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CategoryDescription = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TaxName = c.String(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        CategoryDescription = c.String(),
                        TaxRateId = c.Long(),
                        CustCatId = c.Long(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerTaxCategories", t => t.CustCatId)
                .ForeignKey("dbo.TaxCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TaxRates", t => t.TaxRateId)
                .Index(t => t.CategoryId)
                .Index(t => t.TaxRateId)
                .Index(t => t.CustCatId);
            
            CreateTable(
                "dbo.TaxRates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TaxRateName = c.String(),
                        TaxRateValue = c.Double(),
                        TaxRateDescription = c.String(),
                        CreatedBy = c.Long(),
                        CreatedAt = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taxes", "TaxRateId", "dbo.TaxRates");
            DropForeignKey("dbo.Taxes", "CategoryId", "dbo.TaxCategories");
            DropForeignKey("dbo.Taxes", "CustCatId", "dbo.CustomerTaxCategories");
            DropIndex("dbo.Taxes", new[] { "CustCatId" });
            DropIndex("dbo.Taxes", new[] { "TaxRateId" });
            DropIndex("dbo.Taxes", new[] { "CategoryId" });
            DropTable("dbo.TaxRates");
            DropTable("dbo.Taxes");
            DropTable("dbo.TaxCategories");
            DropTable("dbo.CustomerTaxCategories");
        }
    }
}
