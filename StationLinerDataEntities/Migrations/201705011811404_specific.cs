namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specific : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nozzles", "NozzleName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nozzles", "NozzleName", c => c.String());
        }
    }
}
