import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { Building } from "../../models/building";
import { Apartament } from "../../models/apartament";
import { ApartamentStatuses } from "../../models/apartamentStatuses";
import { BuildingService } from "../../services/BuildingService";
import { BuildingFloor } from "../../models/buildingFloor";
import { Headers, Http, RequestOptionsArgs } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Resources } from "../../../ServiceResources";
import { BuildingEntranceEndpoint } from "../../services/buildingEntrance-endpoint";
import { BuildingEntrance } from "../../models/buildingEntrance";
import { BuildingFloorService } from "../../services/BuildingFloor.service";
import { AlertService, MessageSeverity } from "../../services/alert.service";

@Component({
    selector: 'app-buildingEntrancesComponent',
    templateUrl: './building-entrances.component.html',
    styleUrls: ['./building-entrances.component.css']
})


export class BuildingEntrancesComponent {

    private selectedEntranceId: number;
    private selectedEntrance: BuildingEntrance;
    private selectedFloors: BuildingFloor[];
    newFloors: BuildingFloor;

    constructor(route: ActivatedRoute, private alertService: AlertService, private http: Http, private buildingEntranceEndpoint: BuildingEntranceEndpoint, private buildingFloorService: BuildingFloorService) {

        this.newFloors = new BuildingFloor();

        var id = route.snapshot.params['id'];
        if (id === undefined) {
        }
        else {
            this.selectedEntranceId = id;
            this.buildingEntranceEndpoint.GetEntranceById(id).subscribe(entr => this.selectedEntrance = entr);
            this.buildingFloorService.GetFloorsByEntranceId(id).subscribe(flr => this.selectedFloors = flr);
        }
    }

    Save() {


        if (this.selectedEntrance != null) {

            this.newFloors.buildingId = this.selectedEntrance.buildingId;
            this.newFloors.buildingEntranceId = this.selectedEntrance.id;

            this.buildingFloorService.AddBuildingFloor(this.newFloors).subscribe(
                bldFloor => {
                    this.selectedFloors.push(bldFloor);                    
                }
            );

            this.newFloors = new BuildingFloor();
        }
        else {
            this.alertService.showMessage("проблем с данните", "Има проблем при избиране на вход-а моля обърнете се към администратор.", MessageSeverity.error);
        }
    }
}