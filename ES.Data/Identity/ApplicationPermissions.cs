using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ES.Data.Identity
{
    public static class ApplicationPermissions
    {
        public static ReadOnlyCollection<ApplicationPermission> AllPermissions;


        public const string UsersPermissionGroupName = "User Permissions";
        public static ApplicationPermission ViewUsers = new ApplicationPermission("View Users", "users.view", UsersPermissionGroupName, "Permission to view other users account details");
        public static ApplicationPermission ManageUsers = new ApplicationPermission("Manage Users", "users.manage", UsersPermissionGroupName, "Permission to create, delete and modify other users account details");

        public const string RolesPermissionGroupName = "Role Permissions";
        public static ApplicationPermission ViewRoles = new ApplicationPermission("View Roles", "roles.view", RolesPermissionGroupName, "Permission to view available roles");
        public static ApplicationPermission ManageRoles = new ApplicationPermission("Manage Roles", "roles.manage", RolesPermissionGroupName, "Permission to create, delete and modify roles");
        public static ApplicationPermission AssignRoles = new ApplicationPermission("Assign Roles", "roles.assign", RolesPermissionGroupName, "Permission to assign roles to users");

        public const string BuildingPermissionGroupName = "Building Permissions";
        public static ApplicationPermission ViewBuildings = new ApplicationPermission("View Buildings", "buildings.view", BuildingPermissionGroupName, "Permission to view all buildings in the system.");
        public static ApplicationPermission ManageBuildings = new ApplicationPermission("Manage Buildings", "buildings.manage", BuildingPermissionGroupName, "Permission to create, delete and modify Buildings");
        public static ApplicationPermission AssignBuildings = new ApplicationPermission("Assign Buildings", "buildings.assign", BuildingPermissionGroupName, "Permission to assign apartaments to buildings");

        public const string ApartamentPermissionGroupName = "Apartament Permissions";
        public static ApplicationPermission ViewApartaments = new ApplicationPermission("View Apartaments", "apartaments.view", ApartamentPermissionGroupName, "Permission to view all apartaments in the system.");
        public static ApplicationPermission ManageApartaments = new ApplicationPermission("Manage Apartaments", "apartaments.manage", ApartamentPermissionGroupName, "Permission to create, delete and modify apartaments");
        public static ApplicationPermission AssignApartaments = new ApplicationPermission("Assign Apartaments", "apartaments.assign", ApartamentPermissionGroupName, "Permission to assign users to apartaments");


        static ApplicationPermissions()
        {
            List<ApplicationPermission> allPermissions = new List<ApplicationPermission>()
            {
                ViewUsers,
                ManageUsers,

                ViewRoles,
                ManageRoles,
                AssignRoles,
                ViewBuildings,
                ManageBuildings,
                AssignBuildings,
                ViewApartaments,
                ManageApartaments,
                AssignApartaments
            };

            AllPermissions = allPermissions.AsReadOnly();
        }

        public static ApplicationPermission GetPermissionByName(string permissionName)
        {
            return AllPermissions.Where(p => p.Name == permissionName).FirstOrDefault();
        }

        public static ApplicationPermission GetPermissionByValue(string permissionValue)
        {
            return AllPermissions.Where(p => p.Value == permissionValue).FirstOrDefault();
        }

        public static string[] GetAllPermissionValues()
        {
            return AllPermissions.Select(p => p.Value).ToArray();
        }

        public static string[] GetAdministrativePermissionValues()
        {
            return new string[] { ManageUsers, ManageRoles, AssignRoles };
        }
    }





    public class ApplicationPermission
    {
        public ApplicationPermission()
        { }

        public ApplicationPermission(string name, string value, string groupName, string description = null)
        {
            Name = name;
            Value = value;
            GroupName = groupName;
            Description = description;
        }



        public string Name { get; set; }
        public string Value { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }


        public override string ToString()
        {
            return Value;
        }


        public static implicit operator string(ApplicationPermission permission)
        {
            return permission.Value;
        }
    }
}
