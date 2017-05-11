namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MenuName = c.String(nullable: false),
                        ParentMenu = c.Long(),
                        Controller = c.String(nullable: false),
                        Action = c.String(nullable: false),
                        Icon = c.String(),
                        Sequence = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentMenu)
                .Index(t => t.ParentMenu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "ParentMenu", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentMenu" });
            DropTable("dbo.Menus");
        }
    }
}
