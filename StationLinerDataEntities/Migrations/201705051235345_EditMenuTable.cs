namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMenuTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "LayoutBase", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "LayoutBase");
        }
    }
}
