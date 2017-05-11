namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeDoublenotrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransactionDetails", "Quantity", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionDetails", "Quantity", c => c.Double(nullable: false));
        }
    }
}
