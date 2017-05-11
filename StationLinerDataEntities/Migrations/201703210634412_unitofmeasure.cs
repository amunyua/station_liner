namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitofmeasure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UOMs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UOMName = c.String(nullable: false),
                        UOMDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UOMs");
        }
    }
}
