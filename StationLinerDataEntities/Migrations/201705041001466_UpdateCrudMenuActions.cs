namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCrudMenuActions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrudMenuActions", "CrudActions", c => c.String());
            DropColumn("dbo.CrudMenuActions", "CrudId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CrudMenuActions", "CrudId", c => c.Long(nullable: false));
            DropColumn("dbo.CrudMenuActions", "CrudActions");
        }
    }
}
