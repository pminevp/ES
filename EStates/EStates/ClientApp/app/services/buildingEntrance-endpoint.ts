import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { BuildingEntranceEndpointService } from "./buildingEntrance-endpoint.service";
import { BuildingEntrance } from "../models/buildingEntrance";

@Injectable()
export class BuildingEntranceEndpoint {

    constructor(private router: Router, private http: Http, private buildingEndpoint: BuildingEntranceEndpointService) {

    }


    GetEntrancesByBuildingId(id: number)
    {
        return this.buildingEndpoint.GetEntrancesByBuildingId(id).map((response: Response) => <BuildingEntrance[]>response.json());
    }

    GetEntranceById(id: number) {
        return this.buildingEndpoint.GetEntranceById(id).map((response:Response)=> <BuildingEntrance>response.json());
    }
}