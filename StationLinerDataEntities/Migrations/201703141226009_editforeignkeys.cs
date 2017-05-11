namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Menus", new[] { "ParentMenu" });
            AlterColumn("dbo.Menus", "ParentMenu", c => c.Long(nullable: true));
            CreateIndex("dbo.Menus", "ParentMenu");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Menus", new[] { "ParentMenu" });
            AlterColumn("dbo.Menus", "ParentMenu", c => c.Long());
            CreateIndex("dbo.Menus", "ParentMenu");
        }
    }
}
