namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editforeignkeys1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "ParentMenu", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentMenu" });
            AlterColumn("dbo.Menus", "ParentMenu", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "ParentMenu", c => c.Long(nullable: false));
            CreateIndex("dbo.Menus", "ParentMenu");
            AddForeignKey("dbo.Menus", "ParentMenu", "dbo.Menus", "Id");
        }
    }
}
