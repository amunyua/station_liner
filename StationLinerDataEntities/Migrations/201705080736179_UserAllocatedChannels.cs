namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAllocatedChannels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAllocatedChannels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ChannelId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Channels_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.Channels_Id)
                .Index(t => t.Channels_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAllocatedChannels", "Channels_Id", "dbo.Channels");
            DropIndex("dbo.UserAllocatedChannels", new[] { "Channels_Id" });
            DropTable("dbo.UserAllocatedChannels");
        }
    }
}
