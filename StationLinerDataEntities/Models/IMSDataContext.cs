using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLinerDataEntities.Models
{
    public class IMSDataEntities : DbContext
    {

        public IMSDataEntities()

            : base("IMSDataEntities") //This is the name of the connection string which will be added to the Web.config later
        {

            //ConnectionTools db = new ConnectionTools();
            //db.ChangeDatabase(null, "FCSMW2", "", "", "", false);
            //DbConnection db = new DbConnection();
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserRoleAllocation> UserRoleAllocations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CRUDAction> CrudActions { get; set; }
        public DbSet<UsersView> AllUsers { get; set; }
        public DbSet<UOM> Uom { get; set; }
        public DbSet<Supplier> Supppliers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<SupplierDriver> Drivers { get; set; }
        public DbSet<SupplierVehicle> Vehicles { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionDetails> TransctionDetails { get; set; }
        public DbSet<TransactionDocuments> TransactionDocuments { get; set; }
        public DbSet<FuelTransactionDetails> FuelTransactionDetails { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<BusinessRoles> BusinessRoles { get; set; }
        public DbSet<ChannelTypes> ChannelTypes { get; set; }
        public DbSet<Channels> Channels { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<CustomerTaxCategory> CustomerTaxCategories { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<NozzleType> NozzleTypes { get; set; }
        public DbSet<Nozzle> Nozzles { get; set; }
        public DbSet<CrudMenuActions> CrudMenuActions { get; set; }
        public DbSet<UserLayout> UserLayout { get; set; }
        public DbSet<UserAllocatedChannels> UserAllocatedChannels { get; set; }




        //method for setting success status
        public string Message(string status, string messageDetail)
        {
            return "Session[\"" + status + "\"]=" + messageDetail;

        }

        public System.Data.Entity.DbSet<StationLinerDataEntities.Models.Staff> Staffs { get; set; }

    }

    

   
}
