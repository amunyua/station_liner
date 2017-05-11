namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addParentIdToMenuAllocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleAllocations", "ParentId", c => c.Long(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoleAllocations", "ParentId");
        }
    }
}
