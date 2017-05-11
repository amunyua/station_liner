namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrudActions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CRUDActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ActionCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CRUDActions");
        }
    }
}
