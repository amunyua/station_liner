namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Staff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PIN = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        ChannelId = c.Long(nullable: false),
                        Role = c.Long(nullable: false),
                        UserId = c.Long(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.Role);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Role", "dbo.Roles");
            DropForeignKey("dbo.Staffs", "ChannelId", "dbo.Channels");
            DropIndex("dbo.Staffs", new[] { "Role" });
            DropIndex("dbo.Staffs", new[] { "ChannelId" });
            DropTable("dbo.Staffs");
        }
    }
}
