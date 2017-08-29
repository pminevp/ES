import { User } from "./user.model";

export class UserRegistration extends User {
    constructor(private _currentPassword?: string, private _newPassword?: string, private _confirmPassword?: string  ) {
                super();

                this.currentPassword = _currentPassword;
                this.newPassword = _newPassword;
                this.confirmPassword = _confirmPassword;
    }

    public currentPassword: string;
    public newPassword: string;
    public confirmPassword: string;

}