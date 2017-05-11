namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatelauyoutstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLayouts", "ChannelId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLayouts", "ChannelId");
        }
    }
}
