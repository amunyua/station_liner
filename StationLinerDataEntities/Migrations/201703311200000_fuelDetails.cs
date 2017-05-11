namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuelDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuelTransactionDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.Long(nullable: false),
                        ExpectedQuantity = c.Double(nullable: false),
                        DipBeforeOffload = c.Double(nullable: false),
                        DipAfterOffload = c.Double(nullable: false),
                        AmountSoldDuringOffload = c.Double(nullable: false),
                        ActualQuantityAvailable = c.Double(nullable: false),
                        PricePerLiter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionDocuments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.Long(nullable: false),
                        DocumentType = c.String(),
                        DocumentPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDocuments", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.TransactionDocuments", new[] { "TransactionId" });
            DropTable("dbo.TransactionDocuments");
            DropTable("dbo.FuelTransactionDetails");
        }
    }
}
