import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { BuildingEndpoint } from "./building-endpoint";
import { Building } from "../models/building";

@Injectable()
export class BuildingService
{
    constructor(private router: Router, private http: Http, private buildingEndpoint: BuildingEndpoint) {

    }


    public GetAllBuildings() {

        return this.buildingEndpoint.GetAllBuildings().map((response: Response) => <Building[]>response.json());
    }

}