namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBusinessRoleStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "BusinessRole", c => c.Long(nullable: false));
            CreateIndex("dbo.Staffs", "BusinessRole");
            AddForeignKey("dbo.Staffs", "BusinessRole", "dbo.BusinessRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "BusinessRole", "dbo.BusinessRoles");
            DropIndex("dbo.Staffs", new[] { "BusinessRole" });
            DropColumn("dbo.Staffs", "BusinessRole");
        }
    }
}
