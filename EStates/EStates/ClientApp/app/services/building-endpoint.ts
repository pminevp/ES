
import { Injectable, Injector } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';
import { Resources } from "../../ServiceResources";

@Injectable()
export class BuildingEndpoint {

    get currentBuildingUrl() { return Resources.BuildingPath; }

    constructor(private http: Http, configurations: ConfigurationService, injector: Injector) {

    }

    GetAllBuildings(): Observable<Response> {

        return this.http.get(this.currentBuildingUrl)
            .map((response: Response) => {
                return response;
            });
    }

}