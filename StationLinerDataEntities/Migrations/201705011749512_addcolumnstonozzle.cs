namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnstonozzle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nozzles", "NozzleName", c => c.String());
            AddColumn("dbo.Nozzles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nozzles", "Description");
            DropColumn("dbo.Nozzles", "NozzleName");
        }
    }
}
