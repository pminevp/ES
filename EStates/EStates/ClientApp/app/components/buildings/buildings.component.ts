
import { Component, OnInit } from "@angular/core";
import { Building } from "../../models/building";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { BuildingService } from "../../services/BuildingService";
import { AlertService, MessageSeverity } from "../../services/alert.service";

@Component({
    selector: "app-building",
    templateUrl: './buildings.component.html',
    styleUrls: ['./buildings.component.css']
})

export class BuildingsComponent implements OnInit {

    private buildings: Building[] = [];
    private newBuilding: Building = new Building();

    constructor(private buildingService: BuildingService, private alertService: AlertService) {

    }

    ngOnInit(): void {

        this.loadCurrentBuildingData();
    }

    private loadCurrentBuildingData() {
        this.buildingService.GetAllBuildings().subscribe(building => this.onBuildingLoadSuccessful(building), error => this.onBuildingLoadFailed(error));
    }

    private onBuildingLoadSuccessful(_building: Building[]) {
        this.buildings = _building;
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
}