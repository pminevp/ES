
import { Injectable, Injector } from '@angular/core';
import { Headers,Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ConfigurationService } from './configuration.service';
import { Resources } from "../../ServiceResources";
import { Building } from "../models/building";
import { EndpointFactory } from "./endpoint-factory.service";
 

@Injectable()
export class BuildingEndpoint extends EndpointFactory {

    get currentBuildingUrl() { return Resources.BuildingPath; }

    constructor( http: Http, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }

    GetAllBuildings(): Observable<Response> {

        return this.http.get(this.currentBuildingUrl)
            .map((response: Response) => {
                return response;
            });
    }

    
    GetBuilding(id: number) : Observable<Response>
    {
        var properAddress = this.currentBuildingUrl + id;
        return this.http.get(properAddress).map((response: Response) => { return response; });
    }

    AddBuilding(building: Building): Observable<Response> 
    {
        var json = JSON.stringify(building); 
        return this.http.post(Resources.BuildingPath, building).map((response: Response) => { return response; });  
    }


    UploadBuildingDocument(formData: FormData) : Observable< Response >
    {
        var properAddress = Resources.BuildingPath + "Documents/";

        let headers = new Headers();
        headers.append('Accept', 'application/json');

        return this.http.post(properAddress, formData, { headers: headers }).map((response: Response) => { return response; });
    }

    protected getAuthHeader(includeJsonContentType?: boolean): RequestOptions {
        let headers = new Headers({ });

        if (includeJsonContentType)
            headers.append("Content-Type", "application/json");

        headers.append("Accept", `application/vnd.iman.v1 json, application/json, text/plain, */*`);
        headers.append("App-Version", ConfigurationService.appVersion);
 
        return new RequestOptions();
    }
 
}