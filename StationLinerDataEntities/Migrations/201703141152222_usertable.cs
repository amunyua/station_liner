namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertable : DbMigration
    {
        public override void Up()
        {
//            CreateTable(
//                "dbo.AspNetUsers",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        AccessFailedCount = c.Int(nullable: false),
//                        Email = c.String(),
//                        EmailConfirmed = c.Boolean(nullable: false),
//                        LockoutEnabled = c.Boolean(nullable: false),
//                        LockoutEndDateUtc = c.DateTime(),
//                        PasswordHash = c.String(),
//                        PhoneNumber = c.String(),
//                        PhoneNumberConfirmed = c.Boolean(nullable: false),
//                        SecurityStamp = c.String(),
//                        TwoFactorEnabled = c.Boolean(nullable: false),
//                        UserName = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
//            
        }
        
        public override void Down()
        {
            DropTable("dbo.AspNetUsers");
        }
    }
}
