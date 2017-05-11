namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInt : DbMigration
    {
        public override void Up()
        {
//            AlterColumn("dbo.UserRoles", "UserId", c => c.Int(nullable: false));
//            CreateIndex("dbo.UserRoles", "UserId");
//            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
//            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
//            DropIndex("dbo.UserRoles", new[] { "UserId" });
//            AlterColumn("dbo.UserRoles", "UserId", c => c.Long(nullable: false));
        }
    }
}
