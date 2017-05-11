namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierDriver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierDrivers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DriverName = c.String(),
                        PhoneNumber = c.String(),
                        SupplierId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierDrivers", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.SupplierDrivers", new[] { "SupplierId" });
            DropTable("dbo.SupplierDrivers");
        }
    }
}
