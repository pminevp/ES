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
import { AlertService, MessageSeverity } from "../../services/alert.service";
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
    public ErrorData: Array<string>;
 

    public ValidationErrors: boolean;
    private isSaving: boolean;
    private isNewBuilding: boolean;

    private newUserRegistragtion: UserRegistration;


    constructor(route: ActivatedRoute, private http: Http, private alertService: AlertService, private apartamentEndpoint: BuildingApartamentEndpoint, private buildingEndpoint: BuildingService, private accountService: AccountService) {
        this.newUserRegistragtion = new UserRegistration();
        this.loadBuildings();
        this.LoadRoles(); 
        this.ValidationErrors = false;
    }

    public save() { 
        this.isSaving = true;
        this.alertService.startLoadingMessage("User Creation");

        this.newUserRegistragtion.newPassword = this.newUserRegistragtion.confirmPassword;

        console.log(this.newUserRegistragtion);

        this.accountService.newAnonimusUserCreation(this.newUserRegistragtion).subscribe((x) => {

            this.isSaving = false;
            this.alertService.stopLoadingMessage();
            if (x.item1 === false) {    
                this.ValidationErrors = true;              

                this.ErrorData = new Array<string>();
                for (var i in x.item2) {
                    this.ErrorData.push(x.item2[i]);
                }              

                this.alertService.showMessage("Проблем с регистрацията","Моля вижте грешките в началото на страницата",MessageSeverity.error);
                console.log(this.ErrorData);
            }
            else
            {
                this.alertService.showMessage("Успешна Регистрация!", "Потребителя ви бе успешно създаден!", MessageSeverity.success);
            }

        }, err => console.log(err));
    }

    public loadApartaments(buildingId: number) {

        console.log(buildingId)
        if (buildingId.toString() != "Добави Сграда")
        {
            console.log(buildingId);
            this.apartamentEndpoint.GetByBuildingId(buildingId).subscribe(aparts => this.availableApartaments = aparts);
        }
        else
        {
         
            this.isNewBuilding = true;
        }

        console.log(this.apartamentEndpoint)
    }

    public loadBuildings() {
        this.buildingEndpoint.GetAllBuildings().subscribe((bld) => {
        this.availableBuildings = bld;

        var newBuilding = new Building();
        newBuilding.name = "Добави Сграда";
        newBuilding.id = -1;

        this.availableBuildings.push(newBuilding);

        });
    }

    public LoadRoles() {
        this.accountService.GetPublicUserRoles().subscribe(rl => this.availableRoles = rl );
    }

    private saveSuccessHelper() {       
        this.isSaving = false;
        this.alertService.stopLoadingMessage();       
    }   
}