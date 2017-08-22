import { Injectable, Injector } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ConfigurationService } from './configuration.service';
import { Resources } from "../../ServiceResources";
import { Building } from "../models/building";
import { EndpointFactory } from "./endpoint-factory.service";
import { Apartament } from "../models/apartament";

@Injectable()

export class BuildingApartamentEndpointService extends EndpointFactory
{
    private readonly _buildingApartamentUrl: string = this.configurations.baseUrl + "/api/BuildingApartament/"

    constructor(http: Http, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    public AddApartament(newApartament: Apartament): Observable<Response>
    {
        return this.http.post(this._buildingApartamentUrl, newApartament).map((response: Response) => { return response; });
    }

    public UpdateApartament(apart: Apartament): Observable<Response> {

        return this.http.put(this._buildingApartamentUrl, apart).map((resp: Response) => { return resp; });
    }

    
    public GetApartamentById(id: number): Observable<Response> {

        return this.http.get(this._buildingApartamentUrl + id).map((resp: Response) => { return resp; });
    }
}