import { Injectable, Injector } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';

@Injectable()
export class BuildingFloorEndpoint extends EndpointFactory {

    private readonly _floorBaseUrl: string = "/api/BuildingFloors/"
    private readonly _buildingEntrancesUrl: string ="/api/BuildingEntrance/Floors/"
    private readonly _ApartamentsByFloorIdUrl: string = this._floorBaseUrl + "ApartamentsByFloorId/";

    public getFloorUrl() { return this.configurations.baseUrl + this._buildingEntrancesUrl; }

    public getFloorsByEntranceUrl() { return this.configurations.baseUrl + this._floorBaseUrl;}

    public getApartamentsByFloorIdUrl() { return this.configurations.baseUrl + this._ApartamentsByFloorIdUrl;}

    constructor(http: Http, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    public GetAllFloors(): Observable<Response> {

        return this.http.get(this._floorBaseUrl).map((response: Response) => { return response;})
    }

    public GetFloor(id: number) {
        return this.http.get(this._floorBaseUrl + id).map((response: Response) => { return response; });
    }

    public GetFloorsByEntranceId(id: number): Observable<Response> {

        return this.http.get(this.getFloorUrl() + id).map((response: Response) => { return response; })
    }

    public GetApartamentsByFloorId(id: number): Observable<Response> {

        return this.http.get(this.getApartamentsByFloorIdUrl() + id).map((response: Response) => { return response; });
    }

}