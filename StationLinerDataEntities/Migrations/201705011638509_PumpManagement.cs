namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PumpManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nozzles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NozzleType = c.Long(nullable: false),
                        PumpId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NozzleTypes", t => t.NozzleType, cascadeDelete: true)
                .ForeignKey("dbo.Pumps", t => t.PumpId, cascadeDelete: true)
                .Index(t => t.NozzleType)
                .Index(t => t.PumpId);
            
            CreateTable(
                "dbo.NozzleTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pumps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ChannelId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nozzles", "PumpId", "dbo.Pumps");
            DropForeignKey("dbo.Pumps", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.Nozzles", "NozzleType", "dbo.NozzleTypes");
            DropIndex("dbo.Pumps", new[] { "ChannelId" });
            DropIndex("dbo.Nozzles", new[] { "PumpId" });
            DropIndex("dbo.Nozzles", new[] { "NozzleType" });
            DropTable("dbo.Pumps");
            DropTable("dbo.NozzleTypes");
            DropTable("dbo.Nozzles");
        }
    }
}
