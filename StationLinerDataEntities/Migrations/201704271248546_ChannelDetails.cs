namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChannelDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChannelName = c.String(nullable: false),
                        ChannelDescription = c.String(),
                        ChannelType = c.Long(),
                        Country = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChannelTypes", t => t.ChannelType)
                .Index(t => t.ChannelType);
            
            CreateTable(
                "dbo.ChannelTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Channels", "ChannelType", "dbo.ChannelTypes");
            DropIndex("dbo.Channels", new[] { "ChannelType" });
            DropTable("dbo.ChannelTypes");
            DropTable("dbo.Channels");
            DropTable("dbo.BusinessRoles");
        }
    }
}
