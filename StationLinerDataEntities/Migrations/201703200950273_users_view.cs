namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users_view : DbMigration
    {
        public override void Up()
        {
//            CreateTable(
//                "dbo.AllUsers",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Email = c.String(),
//                        EmailConfirmed = c.Boolean(nullable: false),
//                        PasswordHash = c.String(),
//                        SecurityStamp = c.String(),
//                        PhoneNumber = c.String(),
//                        PhoneNumberConfirmed = c.Boolean(nullable: false),
//                        TwoFactorEnabled = c.Boolean(nullable: false),
//                        LockoutEndDateUtc = c.DateTime(),
//                        LockoutEnabled = c.Boolean(nullable: false),
//                        AccessFailedCount = c.Int(nullable: false),
//                        UserName = c.String(),
//                        RoleName = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AllUsers");
        }
    }
}
