namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierVehicles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierVehicles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RegNumber = c.String(),
                        MaximumCapacity = c.String(),
                        SupplierId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierVehicles", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.SupplierVehicles", new[] { "SupplierId" });
            DropTable("dbo.SupplierVehicles");
        }
    }
}
