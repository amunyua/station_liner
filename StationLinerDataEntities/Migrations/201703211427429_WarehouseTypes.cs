namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarehouseTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarehouseTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarehouseTypes");
        }
    }
}
