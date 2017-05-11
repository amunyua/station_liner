namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCrudActionsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleAllocations", "CrudActions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoleAllocations", "CrudActions");
        }
    }
}
