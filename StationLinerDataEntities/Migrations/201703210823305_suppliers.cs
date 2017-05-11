namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suppliers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Contact1 = c.String(nullable: false),
                        Contact2 = c.String(),
                        Email = c.String(),
                        PinNumber = c.String(),
                        ContactPersonName = c.String(),
                        CreditLimit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
        }
    }
}
