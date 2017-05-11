    namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatelauyoutstable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserLayouts", "ChannelId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLayouts", "ChannelId", c => c.Long(nullable: false));
        }
    }
}
