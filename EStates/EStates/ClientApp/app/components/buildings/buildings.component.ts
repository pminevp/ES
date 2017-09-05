import { Component, OnInit } from "@angular/core";
import { Building } from "../../models/building";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { BuildingService } from "../../services/BuildingService";
import { AlertService, MessageSeverity } from "../../services/alert.service";
import { Permission } from "../../models/permission.model";
import { AccountService } from "../../services/account.service";

@Component({
    selector: "app-building",
    templateUrl: './buildings.component.html',
    styleUrls: ['./buildings.component.css']
})

export class BuildingsComponent implements OnInit {

    private buildings: Building[] = [];
    private newBuilding: Building = new Building();

    constructor(private buildingService: BuildingService, private alertService: AlertService, private accountService: AccountService) {
    }

    ngOnInit(): void {

        this.loadCurrentBuildingData();
    }

    private loadCurrentBuildingData() {

        var userId = this.accountService.currentUser.id;

        this.buildingService.GetBuildingByOwner(userId).subscribe(building => {
            this.onBuildingLoadSuccessful(building);
            if (this.buildings.length == 1) {

                if (this.accountService.userHasPermission(Permission.AssignBuildingsPermission) == false) {
                    window.location.href = "building-details/" + this.buildings[0].id
                }
            }
        }
            , error => this.onBuildingLoadFailed(error));
    }

    private onBuildingLoadSuccessful(_building: Building) {
        this.buildings = new Array<Building>();
        this.buildings.push(_building);
    }

    private onBuildingLoadFailed(error: any) {
        console.log(error);
    }

    public Save(){

        this.buildings.push(this.newBuilding);       
        this.buildingService.AddBuilding(this.newBuilding).subscribe(x => console.log(x));                
          
        this.alertService.showStickyMessage("Добавена Сграда!", "Сградата: " + this.newBuilding.name + " Беше добавена успешно!", MessageSeverity.default);
        this.newBuilding = new Building();
    }

    //Filtrates do we have permission to Create
    get IsGlobalAdmin() {
        return this.accountService.userHasPermission(Permission.ManageBuildingsPermission);          
    }   
}