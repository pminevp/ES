﻿// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { User } from './user.model';


export class UserEdit extends User {
    constructor(currentPassword?: string, newPassword?: string, confirmPassword?: string, buildingId?: number) {
        super();

        this.currentPassword = currentPassword;
        this.newPassword = newPassword;
        this.confirmPassword = confirmPassword;
        this.buildingId = buildingId;
    }

    public currentPassword: string;
    public newPassword: string;
    public confirmPassword: string;
    public buildingId: number;

}