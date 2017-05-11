namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignkeyChannelId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Channel", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "Channel");
            AddForeignKey("dbo.AspNetUsers", "Channel", "dbo.Channels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Channel", "dbo.Channels");
            DropIndex("dbo.AspNetUsers", new[] { "Channel" });
            DropColumn("dbo.AspNetUsers", "Channel");
        }
    }
}
