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
import { BuildingEntranceEndpoint } from "../../services/buildingEntrance-endpoint";
import { BuildingEntrance } from "../../models/buildingEntrance";
import { AccountService } from "../../services/account.service";
import { Permission } from "../../models/permission.model";
 
@Component({
    selector: 'app-buildingDetails',
    templateUrl: './building-details.component.html',
    styleUrls: ['./building-details.component.css']
})

export class BuildingDetailsComponent {

    private selectedBuildingId: number;
    private selectedBuilding: Building;
    private selectedFloors: Array<BuildingFloor>
    private newEntrance: BuildingEntrance;
    private buildingEntrances: BuildingEntrance[];

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingService, private http: Http, private buildingEntranceEndpoint: BuildingEntranceEndpoint, private accountService: AccountService)
    {
        this.newEntrance = new BuildingEntrance();
        var id = route.snapshot.params['id'];
        if (id === undefined) {           
        }
        else { 
            this.selectedBuildingId = id;
            buildingsEndpoint.GetBuilding(id).subscribe(bld => this.selectedBuilding = bld);

      
            if (this.accountService.userHasPermission(Permission.AssignBuildingsPermission)) {
                buildingEntranceEndpoint.GetEntrancesByBuildingId(id).subscribe(entr => this.buildingEntrances = entr);  
            }
            else
            {
                buildingEntranceEndpoint.GetEntrances(id, this.accountService.currentUser.id).subscribe(entr => this.buildingEntrances = entr);
            }
        }
    }

    Save() {

        var apartStat = new ApartamentStatuses(); 
        this.buildingEntrances.push(this.newEntrance);
        this.newEntrance = new BuildingEntrance();
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