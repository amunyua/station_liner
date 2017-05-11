namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrudMenuActions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrudMenuActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MenuId = c.Long(nullable: false),
                        CrudId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "AdminBased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "AdminBased");
            DropTable("dbo.CrudMenuActions");
        }
    }
}
