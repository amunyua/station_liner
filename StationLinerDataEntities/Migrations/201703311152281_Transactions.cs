namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionType = c.String(),
                        TransactionCategory = c.String(),
                        TransactionDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        ReceivedBy = c.Long(nullable: false),
                        DeliveryNote = c.String(),
                        InvoiceRefNumber = c.String(),
                        SupplierId = c.Long(nullable: false),
                        DriverId = c.Long(nullable: false),
                        VehicleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Transactions", new[] { "SupplierId" });
            DropTable("dbo.Transactions");
        }
    }
}
