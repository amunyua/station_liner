namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropforeinkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            AlterColumn("dbo.UserRoles", "UserId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRoles", "UserId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
