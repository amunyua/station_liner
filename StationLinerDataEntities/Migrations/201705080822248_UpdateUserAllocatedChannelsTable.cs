namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAllocatedChannelsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAllocatedChannels", "Channels_Id", "dbo.Channels");
            DropIndex("dbo.UserAllocatedChannels", new[] { "Channels_Id" });
            DropColumn("dbo.UserAllocatedChannels", "ChannelId");
            RenameColumn(table: "dbo.UserAllocatedChannels", name: "Channels_Id", newName: "ChannelId");
            AlterColumn("dbo.UserAllocatedChannels", "ChannelId", c => c.Long(nullable: false));
            CreateIndex("dbo.UserAllocatedChannels", "ChannelId");
            AddForeignKey("dbo.UserAllocatedChannels", "ChannelId", "dbo.Channels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAllocatedChannels", "ChannelId", "dbo.Channels");
            DropIndex("dbo.UserAllocatedChannels", new[] { "ChannelId" });
            AlterColumn("dbo.UserAllocatedChannels", "ChannelId", c => c.Long());
            RenameColumn(table: "dbo.UserAllocatedChannels", name: "ChannelId", newName: "Channels_Id");
            AddColumn("dbo.UserAllocatedChannels", "ChannelId", c => c.Long(nullable: false));
            CreateIndex("dbo.UserAllocatedChannels", "Channels_Id");
            AddForeignKey("dbo.UserAllocatedChannels", "Channels_Id", "dbo.Channels", "Id");
        }
    }
}
