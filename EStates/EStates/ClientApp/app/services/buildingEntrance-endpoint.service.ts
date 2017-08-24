import { Injectable, Injector } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ConfigurationService } from './configuration.service';
import { Resources } from "../../ServiceResources";
import { Building } from "../models/building";
import { EndpointFactory } from "./endpoint-factory.service"; 

@Injectable()
export class BuildingEntranceEndpointService extends EndpointFactory
{
    private readonly _buildingEntrancUrl: string = this.configurations.baseUrl + "/api/BuildingEntrance/"

    private readonly _BuildingEntranceByUserAndBuildingId: string = this.configurations.baseUrl + "/api/BuildingEntrance/SelectEntrances/"

    private readonly _buildingEntranceByIdUrl: string = this.configurations.baseUrl + "/api/BuildingEntrance/ById/"

    constructor(http: Http, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    public GetEntrancesByBuildingId(id: number): Observable<Response> {

        return this.http.get(this._buildingEntrancUrl + id).map((response: Response) => { return response; });
    }

    public GetEntranceById(id: number): Observable<Response> {

        return this.http.get(this._buildingEntranceByIdUrl + id).map((response: Response) => { return response; });
    }

    public GetEntrancesByBuildingIdAndUserId(buildngId: number, userId: string): Observable<Response> {

        return this.http.get(this._BuildingEntranceByUserAndBuildingId + buildngId+"/"+ userId + "/").map((resp: Response) => { return resp; });
    }
}