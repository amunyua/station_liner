namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(),
                        VAT = c.String(),
                        Location = c.String(),
                        PinNumber = c.String(),
                        Contact1 = c.String(),
                        Contact2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralSettings");
        }
    }
}
