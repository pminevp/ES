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

@Component({
    selector: 'app-buildingDetails',
    templateUrl: './building-entrances.component.html',
    styleUrls: ['./building-entrances.component.css']
})


export class BuildingEntrancesComponent {

    private selectedEntranceId: number;
    private selectedEntrance: BuildingEntrance;
    private selectedFloors: BuildingFloor[];
    newFloors: BuildingFloor;

    constructor(route: ActivatedRoute, private http: Http, private buildingEntranceEndpoint: BuildingEntranceEndpoint, private buildingFloorService: BuildingFloorService) {

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
      
        this.selectedFloors.push(this.newFloors);
        this.newFloors = new BuildingFloor();
    }
}