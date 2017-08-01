import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { Building } from "../../models/building";
import { Apartament } from "../../models/apartament";
import { ApartamentStatuses } from "../../models/apartamentStatuses";

@Component({
    selector: 'app-buildingDetails',
    templateUrl: './building-details.component.html',
    styleUrls: ['./building-details.component.css']
})

export class BuildingDetailsComponent {

    private selectedBuildingId: number;
    selectedBuilding: Building;
    selectedApartaments: Array<Apartament>
    newApartament: Apartament;

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingsEndpointService)
    {
        this.newApartament = new Apartament();
        var id = route.snapshot.params['id'];
        if (id === undefined) {           
        }
        else { 
            this.selectedBuildingId = id;
            this.selectedBuilding = buildingsEndpoint.GetSelectedBuilding(id);
            //this.selectedApartaments = this.selectedBuilding.apartaments;

            //console.log(this.selectedApartaments);
        }
    }

    Save() {

        var apartStat = new ApartamentStatuses();
        this.newApartament.status = apartStat.Normal;
        console.log(this.newApartament);
        //this.selectedBuilding.apartaments.push(this.newApartament);
    }
 
}