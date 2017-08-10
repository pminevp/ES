import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map'; 
import { BuildingFloorEndpoint } from "./buildingfloor-endpoint.service";
import { BuildingFloor } from "../models/buildingFloor";

@Injectable()
export class BuildingFloorService {

    constructor(private router: Router, private http: Http, private BuildingFloorEndpoint: BuildingFloorEndpoint) {

    }

    GetFloorsByEntranceId(id: number) {
        return this.BuildingFloorEndpoint.GetFloorsByEntranceId(id).map((response: Response) => { return <BuildingFloor[]>response.json(); });
    }
}