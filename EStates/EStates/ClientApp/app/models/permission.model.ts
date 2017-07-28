//-------------------
// authentication roles in Typescipt

export type PermissionNames =
    "View Users" | "Manage Users" |
    "View Roles" | "Manage Roles" | "Assign Roles"
    | "View Buildings" | "Manage Buildings" | "Assign Buildings"
    | "View Apartaments" | "Manage Apartaments" | "Assign Apartaments" ;

export type PermissionValues =
    "users.view" | "users.manage" |
    "roles.view" | "roles.manage" | "roles.assign"
    | "buildings.view" | "buildings.manage" | "buildings.assign"
    | "apartaments.view" | "apartaments.manage" | "apartaments.assign";

export class Permission {

    public static readonly viewUsersPermission: PermissionValues = "users.view";
    public static readonly manageUsersPermission: PermissionValues = "users.manage";

    public static readonly viewRolesPermission: PermissionValues = "roles.view";
    public static readonly manageRolesPermission: PermissionValues = "roles.manage";
    public static readonly assignRolesPermission: PermissionValues = "roles.assign";

    public static readonly viewBuildingsPermission: PermissionValues = "buildings.view";
    public static readonly ManageBuildingsPermission: PermissionValues = "buildings.manage";
    public static readonly AssignBuildingsPermission: PermissionValues = "buildings.assign";

    public static readonly viewApartamentsPermission: PermissionValues = "apartaments.view";
    public static readonly ManageApartamentsPermission: PermissionValues = "apartaments.manage";
    public static readonly AssignApartamentsPermission: PermissionValues = "apartaments.assign";


    constructor(name?: PermissionNames, value?: PermissionValues, groupName?: string, description?: string) {
        this.name = name;
        this.value = value;
        this.groupName = groupName;
        this.description = description;
    }

    public name: PermissionNames;
    public value: PermissionValues;
    public groupName: string;
    public description: string;
}