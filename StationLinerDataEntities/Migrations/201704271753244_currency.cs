namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CurrencyName = c.String(),
                        CurrencySymbol = c.String(),
                        RatioToBase = c.Double(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Currencies");
        }
    }
}
