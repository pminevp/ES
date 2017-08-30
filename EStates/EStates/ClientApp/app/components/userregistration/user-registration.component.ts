import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { Building } from "../../models/building";
import { Apartament } from "../../models/apartament";
import { ApartamentStatuses } from "../../models/apartamentStatuses";
import { BuildingService } from "../../services/BuildingService";
import { BuildingFloor } from "../../models/buildingFloor";
import { Headers, Http, RequestOptionsArgs } from "@angular/http";
import { UserRegistration } from "../../models/user-registration.model";
import { AlertService } from "../../services/alert.service";
import { BuildingApartamentEndpoint } from "../../services/buildingApartament-endpoint";
import { AccountService } from "../../services/account.service";
import { UserEdit } from "../../models/user-edit.model";
import { Role } from "../../models/role.model";

@Component({
    selector: 'app-userRegistration',
    templateUrl: './user-registration.component.html',
    styleUrls: ['./user-registration.component.html']
})

export class UserRegistrationComponent {

    private availableApartaments: Apartament[];
    private availableBuildings: Building[];
    private availableRoles: Role[];

    private isSaving: boolean;
    private newUserRegistragtion: UserEdit;


    constructor(route: ActivatedRoute, private http: Http, private alertService: AlertService, private apartamentEndpoint: BuildingApartamentEndpoint, private buildingEndpoint: BuildingService, private accountService: AccountService) {
        this.newUserRegistragtion = new UserEdit();
        this.loadBuildings();
        this.LoadRoles();
    }

    public save() { 
        this.isSaving = true;
        this.alertService.startLoadingMessage("User Creation");

        this.newUserRegistragtion.newPassword = this.newUserRegistragtion.confirmPassword;
        this.newUserRegistragtion.buildingId = 1;

        this.accountService.newAnonimusUserCreation(this.newUserRegistragtion).subscribe(x => console.log(x),err=> console.log(err));
    }

    public loadApartaments(buildingId: number) {
        this.apartamentEndpoint.GetByBuildingId(buildingId).subscribe(aparts => this.availableApartaments = aparts);
    }

    public loadBuildings() {
        this.buildingEndpoint.GetAllBuildings().subscribe(bld => this.availableBuildings = bld);
    }

    public LoadRoles() {
        this.accountService.GetPublicUserRoles().subscribe(rl => this.availableRoles = rl );
    }

    private saveSuccessHelper() {       
        this.isSaving = false;
        this.alertService.stopLoadingMessage();       
    }   
}