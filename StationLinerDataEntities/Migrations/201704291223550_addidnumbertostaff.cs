namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addidnumbertostaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "IdNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "PIN", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Staffs", "PIN", c => c.String());
            AlterColumn("dbo.Staffs", "Email", c => c.String());
            AlterColumn("dbo.Staffs", "Name", c => c.String());
            DropColumn("dbo.Staffs", "IdNumber");
        }
    }
}
