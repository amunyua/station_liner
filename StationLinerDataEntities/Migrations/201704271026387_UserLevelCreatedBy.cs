namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLevelCreatedBy : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.AllUsers", "CreatedBy", c => c.Long(nullable: false));
            AddColumn("dbo.Roles", "UserLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Roles", "CreatedBy", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.Long(nullable: false));
        }
            
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreatedBy");
            DropColumn("dbo.Roles", "CreatedBy");
            DropColumn("dbo.Roles", "UserLevel");
            DropColumn("dbo.AllUsers", "CreatedBy");
        }
    }
}
