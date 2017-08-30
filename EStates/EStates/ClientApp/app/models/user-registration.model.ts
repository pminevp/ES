import { User } from "./user.model";

export class UserRegistration  {
    constructor(private _newPassword?: string, private _confirmPassword?: string, _userName?: string, _fullName?: string, private _email?: string, private _roleName?: string, private _buildingName ? : string    ) {
               
        this.newPassword = _newPassword;
        this.confirmPassword = _confirmPassword;
        this.userName = _userName;
        this.fullName = _fullName;
        this.email = _email;
        this.roleName = _roleName;
        this.buildingName = _buildingName;                 
    }

    public newPassword: string;
    public confirmPassword: string;

    public userName: string;
    public fullName: string;
    public email: string;
    public roleName: string;
    public buildingName: string;
    public apartName: string;
    public buildingEntrance: string;
}