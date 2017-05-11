namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeletedColumninchannelstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Channels", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Channels", "IsDeleted");
        }
    }
}
