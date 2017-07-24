import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { Building } from "../../models/building";

@Component({
    selector: 'app-buildingDetails',
    templateUrl: './building-details.component.html',
    styleUrls: ['./building-details.component.css']
})

export class BuildingDetailsComponent {

    private selectedBuildingId: number;
    private selectedBuilding: Building;

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingsEndpointService)
    {
        var id = route.snapshot.params['id'];
        if (id === undefined) {           
        }
        else {
            this.selectedBuildingId = id;
            this.selectedBuilding = buildingsEndpoint.GetSelectedBuilding(id);
        }
    }
}