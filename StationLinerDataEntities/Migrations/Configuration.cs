using System.Diagnostics;
using StationLinerDataEntities.Models;
using Microsoft.AspNet.Identity;


namespace StationLinerDataEntities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StationLinerDataEntities.Models.IMSDataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StationLinerDataEntities.Models.IMSDataEntities context)
        {
            //create crud actions
            context.CrudActions.AddOrUpdate(a=>a.ActionCode, new CRUDAction{ ActionCode = "ADD", Description = "Can Add an entry"});
            context.CrudActions.AddOrUpdate(a=>a.ActionCode, new CRUDAction{ ActionCode = "EDIT", Description = "Can Edit an entry"});
            context.CrudActions.AddOrUpdate(a=>a.ActionCode, new CRUDAction{ ActionCode = "DELETE", Description = "Can Delete an entry"});
            //create the admins user role
            context.Roles.AddOrUpdate(
                r => r.RoleName, new Models.Roles { RoleName = "SystemAdmin", Description = "Super admin"}
                );

            //get the id of the system admin role
            var roleId = context.Roles.FirstOrDefault(r => r.RoleName == "SystemAdmin").RoleId;

            //get the default user and give them system admins role
            var admin = context.Users.FirstOrDefault();
            if (admin != null)
            {
//                context.UserRoles.AddOrUpdate(
//                    x => x.UserId, new UserRoles { UserId = admin.Id, RoleId = roleId}
//                    );
            }
            
            

            //parent menu for dashboard
            var dashboard = new Menu { Status = true, MenuName = "Dashboard", Controller = "#", Action = "#", Icon = "fa fa-dashboard text-yellow", Sequence = 1,LayoutBase = DataLayerConstants.AdminMode};

            context.Menus.AddOrUpdate(
                m => m.MenuName, dashboard
                );
            var dashboardId = dashboard.Id;
            //analytical dashboard
            var analyticalDashboard = new Menu
            {
                Status = true,
                MenuName = "Analitical Dashboard",
                ParentMenu = dashboardId,
                Controller = "Dashboard",
                Action = "Index",
                Icon = "",
                Sequence = 1
            };
            context.Menus.AddOrUpdate(m => m.MenuName,analyticalDashboard);

            AssignRole(roleId,analyticalDashboard.Id,dashboardId,null);

           
            
            
            
            //############################################### User Settings #############################################################
            //parent menu for user settings
            var userSettings = new Menu { Status = true, MenuName = "User Settings", Controller = "#", Action = "#", Icon = "fa fa-user text-yellow", Sequence = 8 ,LayoutBase = DataLayerConstants.AdminMode};
            context.Menus.AddOrUpdate(
                m => m.MenuName, userSettings
                );
            var userSettingsId = userSettings.Id;
            //////////////// children menus
            var roles = new Menu { Status = true, MenuName = "Manage Roles", Controller = "Roles", Action = "Index", Icon = "#", Sequence = 1, ParentMenu = userSettingsId };

            context.Menus.AddOrUpdate(m => m.MenuName, roles);
            ChildMenu(context, "Manage Roles", "Roles", "Index", 1, userSettingsId, roleId,"{1,2,3}");

//            AssignRole(roleId, roles.Id, userSettingsId,"{1,2,3}");
            //manage users
            var manageUsers = new Menu { Status = true, MenuName = "Manage Users", Controller = "Manage", Action = "Index", Icon = "#", Sequence = 2, ParentMenu = userSettingsId };
            context.Menus.AddOrUpdate(m => m.MenuName, manageUsers);
            AssignRole( roleId, manageUsers.Id, userSettingsId,"{1,2,3}");


            //############################################### System Settings #############################################################
            //parent menu for system settings
            var systemSettings = new Menu { Status = true, MenuName = "System Settings", Controller = "#", Action = "#", Icon = "fa fa-gears text-yellow", Sequence = 9 ,LayoutBase = DataLayerConstants.AdminMode};
            context.Menus.AddOrUpdate(
                m => m.MenuName, systemSettings
                );
            var systemSettingsId = systemSettings.Id;
            //////////////////// children menus for system settings
            var manageMenu = new Menu { Status = true, MenuName = "Manage Menu", Controller = "Menus", Action = "Index", Icon = "#", Sequence = 1, ParentMenu = systemSettingsId };
            
            context.Menus.AddOrUpdate(m => m.MenuName, manageMenu);

            AssignRole(roleId, manageMenu.Id, systemSettingsId,"{1,2,3}");
            ChildMenu(context, "General Settings", "GeneralSettings", "Index", 2, systemSettingsId, roleId,"{1,2,3}");



            //##################### Inventory Module###############
            //parent
            var suppliersParent = ParentMenu(context,"Suppliers", 2,DataLayerConstants.AdminMode);

            //manage suppliers
            ChildMenu(context, "Manage Suppliers", "Suppliers", "Index", 2, suppliersParent, roleId,"{1,2,3}");

            //################## Proucts module

            var productsParent = ParentMenu(context, "Products", 3,DataLayerConstants.AdminMode);
            //children
            ChildMenu(context, "Manage Uom", "UOM", "Index", 2, productsParent, roleId,"{1,2,3}");
            //manage products categories
            ChildMenu(context, "Manage Product Categories", "ProductCategories", "Index", 1, productsParent, roleId,"{1,2,3}");
            ChildMenu(context, "Manage Products", "Products", "Index", 1, productsParent, roleId,"{1,2,3}");

            //################## Warehouses
            var warehouseParent = ParentMenu(context, "Warehouses", 4,DataLayerConstants.AdminMode);
            //warehouse types
            ChildMenu(context, "Manage Warehouse Types", "WarehouseTypes", "Index", 1, warehouseParent, roleId,"{1,2,3}");
            ChildMenu(context, "Manage Warehouses", "Warehouses", "Index", 2, warehouseParent, roleId,"{1,2,3}");

            //parent menu for sock management
            var stockParent = ParentMenu(context, "Stock Management",5, DataLayerConstants.AdminMode);
            ChildMenu(context, "Manage Stock", "Stock", "Index", 1, stockParent, roleId,"{1,2,3}");
            ChildMenu(context, "Stock Transaction", "Stock", "Create", 2, stockParent, roleId,"{1,2,3}");
            ChildMenu(context, "Transactions", "Stock", "Transactions", 3, stockParent, roleId,"{1,2,3}");

            //######### Channel Management
            //parent
            var ChannelParent = ParentMenu(context, "Channel Management", 6,DataLayerConstants.ChannelMode);
            //children
            ChildMenu(context, "Manage Channels", "Channels", "Index", 1, ChannelParent, roleId,"{1,2,3}");

            //######### Tax Management
            //parent
            var taxManagementParent = ParentMenu(context, "Tax Management", 7,DataLayerConstants.AdminMode);
            //children
            ChildMenu(context, "Tax List", "Taxes", "Index", 1, taxManagementParent, roleId,"{1,2,3}");
            ChildMenu(context, "Tax Categories", "TaxCategories", "Index", 2, taxManagementParent, roleId,"{1,2,3}");
            ChildMenu(context, "Tax Rates", "TaxRates", "Index", 3, taxManagementParent, roleId,"{1,2,3}");
            ChildMenu(context, "Customer Tax Categories", "CustomerTaxCategories", "Index", 4, taxManagementParent, roleId,"{1,2,3}");


            //######### staff Management
            //parent
            var staffManagement = ParentMenu(context, "Staff Management", 8,DataLayerConstants.AdminMode);
            ChildMenu(context, "Staff", "Staffs", "Index", 1, staffManagement, roleId,"{1,2,3}");

            //######### Shift Management
            var shiftManagement = ParentMenu(context, "Shift Management", 9,DataLayerConstants.ChannelMode);
            ChildMenu(context, "Shifts", "Shifts", "Index", 1, shiftManagement, roleId,"{1,2,3}");

            //######### Shift Management
            var pumpManagement = ParentMenu(context, "Pump Management", 10,DataLayerConstants.AdminMode);
            ChildMenu(context, "Pumps", "Pumps", "Index", 1, pumpManagement , roleId,"{1,2,3}");
            ChildMenu(context, "Nozzle Types", "NozzleTypes", "Index", 2, pumpManagement , roleId,"{1,2,3}");
            ChildMenu(context, "Nozzles", "Nozzles", "Index", 3, pumpManagement , roleId,"{1,2,3}");



        }



        public long ParentMenu(StationLinerDataEntities.Models.IMSDataEntities context,string menuName, int sequence,string mode)
        {
//            var context = new IMSDataEntities();
            var parentMenu = new Menu { Status = true, MenuName = menuName, Controller = "#", Action = "#", Icon = "fa fa-gears text-yellow", Sequence = sequence,LayoutBase = mode};
            context.Menus.AddOrUpdate(
                m => m.MenuName, parentMenu
                );
            return parentMenu.Id;
        }

        public void ChildMenu(StationLinerDataEntities.Models.IMSDataEntities context, string childMenuName, string controller, string action, int sequence, long parentId, long roleId,string cruds)
        {
//            var context = new IMSDataEntities();
            var childMenu = new Menu { Status = true, MenuName = childMenuName, Controller = controller, Action = action, Icon = "#", Sequence = sequence, ParentMenu = parentId };

            context.Menus.AddOrUpdate(m => m.MenuName, childMenu);
            context.CrudMenuActions.AddOrUpdate(m=>m.MenuId, new Models.CrudMenuActions{MenuId = childMenu.Id,CrudActions = cruds});

            AssignRole(roleId, childMenu.Id, parentId,cruds);
        }
        
        
        
        
        
        
        
        public void AssignRole(long roleId, long menuId, long parentId,string cruds)
        {
            var context = new IMSDataEntities();

            var count = context.UserRoleAllocations.Where(x => x.RoleId == roleId && x.MenuId == menuId);
            if (!count.Any())
            {
                context.UserRoleAllocations.Add(
                    
                    new UserRoleAllocation
                    {
                        MenuId = menuId,
                        RoleId = roleId,
                        ParentId = parentId,
                        CrudActions = cruds
                    }
                );
                context.SaveChanges();
            }
        }

        public string AddCrudActions(long menuId,string cruds)
        {
            string actions = null;
//            var allActions = (cruds != "") ? cruds.TrimStart(new char[] {' ', ','}).TrimEnd(new char[] {',', ' '}) : null;
//            if (allActions != null)
//            {
//                var actionsArray = allActions.Split(',');
//            }


            return actions;
        }
    }
}
