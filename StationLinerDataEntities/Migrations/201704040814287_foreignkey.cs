namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FuelTransactionDetails", "TransactionId");
            AddForeignKey("dbo.FuelTransactionDetails", "TransactionId", "dbo.Transactions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelTransactionDetails", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.FuelTransactionDetails", new[] { "TransactionId" });
        }
    }
}
