namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRolesAllocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleAllocations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleId = c.Long(nullable: false),
                        MenuId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleAllocations", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoleAllocations", "MenuId", "dbo.Menus");
            DropIndex("dbo.UserRoleAllocations", new[] { "MenuId" });
            DropIndex("dbo.UserRoleAllocations", new[] { "RoleId" });
            DropTable("dbo.UserRoleAllocations");
        }
    }
}
