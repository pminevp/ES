import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { BuildingApartamentEndpointService } from "./buildingApartament-endpoint.service";
import { Apartament } from "../models/apartament";

@Injectable()
export class BuildingApartamentEndpoint{

    constructor(private router: Router, private http: Http, private buildingEndpointService: BuildingApartamentEndpointService) {

    }

    GetById(id: number) {
        return this.buildingEndpointService.GetApartamentById(id).map((resp: Response) => <Apartament>resp.json());
    }

    AddApartament(newApartament: Apartament) {

        return this.buildingEndpointService.AddApartament(newApartament).map((resp: Response) => <Apartament>resp.json());
    }

    UpdateApartament(apart: Apartament) {
        return this.buildingEndpointService.UpdateApartament(apart).map((resp: Response) => <Apartament>resp.json());
    }
}