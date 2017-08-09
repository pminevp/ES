import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { Building } from "../../models/building";
import { Apartament } from "../../models/apartament";
import { ApartamentStatuses } from "../../models/apartamentStatuses"; 
import { BuildingService } from "../../services/BuildingService";
import { BuildingFloor } from "../../models/buildingFloor";
import {  Headers,Http, RequestOptionsArgs } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Resources } from "../../../ServiceResources";
 
@Component({
    selector: 'app-buildingDetails',
    templateUrl: './building-details.component.html',
    styleUrls: ['./building-details.component.css']
})

export class BuildingDetailsComponent {

    private selectedBuildingId: number;
    selectedBuilding: Building;
    selectedFloors: Array<BuildingFloor>
    newFloor: BuildingFloor;

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingService, private http : Http)
    {
        this.newFloor = new Apartament();
        var id = route.snapshot.params['id'];
        if (id === undefined) {           
        }
        else { 
            this.selectedBuildingId = id;
            buildingsEndpoint.GetBuilding(id).subscribe(bld => this.selectedBuilding = bld);
        }
    }

    Save() {

        var apartStat = new ApartamentStatuses();
        console.log(this.newFloor);
    }

    fileChange(event) {
   
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            formData.append('test', 'bigTest');

            this.buildingsEndpoint.UploadBuildingDocument(formData).subscribe(data => console.log("yeei"), error => console.log(error));
        }
    }
}