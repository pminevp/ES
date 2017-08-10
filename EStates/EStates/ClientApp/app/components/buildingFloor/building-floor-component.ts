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
import { BuildingFloorService } from "../../services/BuildingFloor.service";

@Component({
    selector: 'app-buildingFloorComponent',
    templateUrl: './building-floor-component.html',
    styleUrls: ['./building-floor-component.css']
})


export class BuildingFloorComponent {

    private selectedFloorId: number;
    private selectedFloor: BuildingFloor;
    private selectedApartaments: Apartament[];
    newApartament: Apartament;

    constructor(route: ActivatedRoute, private http: Http, private buildingFloorEndpoint: BuildingFloorService) {

        this.newApartament = new Apartament();

        var id = route.snapshot.params['id'];
        if (id === undefined) {
        }
        else {
            this.selectedFloorId = id;
            this.buildingFloorEndpoint.GetFloorById(id).subscribe(floor => this.selectedFloor = floor);
            this.buildingFloorEndpoint.GetApartamentsByFloorId(id).subscribe(aprt => this.selectedApartaments = aprt);
        }
    }

    Save() {
        this.selectedApartaments.push(this.newApartament);
        this.newApartament = new Apartament();
    }

}