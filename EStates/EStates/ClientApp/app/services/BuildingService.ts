import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { BuildingEndpoint } from "./building-endpoint";
import { Building } from "../models/building";
 
import { EndpointFactory } from "./endpoint-factory.service";
import { ConfigurationService } from "./configuration.service";

@Injectable()
export class BuildingService
{
    constructor(private router: Router, private http: Http, private buildingEndpoint: BuildingEndpoint) {

    }


    public GetAllBuildings() {

        return this.buildingEndpoint.GetAllBuildings().map((response: Response) => <Building[]>response.json());
    }

    public GetBuilding(id: number)
    {
        return this.buildingEndpoint.GetBuilding(id).map((response: Response) => <Building>response.json());
    }

    public GetBuildingByOwner(ownerId: string) {
        return this.buildingEndpoint.GetBuildingByOwnerId(ownerId).map((resp: Response) => <Building>resp.json());
    }

    public AddBuilding(building: Building)
    {
      return  this.buildingEndpoint.AddBuilding(building).map((response: Response) => <Building[]>response.json());
    }

    public UploadBuildingDocument(formData: FormData)
    {
        return this.buildingEndpoint.UploadBuildingDocument(formData).map((response: Response) => response);
    }

}