import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { EndpointFactory } from "./endpoint-factory.service";
import { ConfigurationService } from "./configuration.service";
import { DockDriveEndpointService } from "./DockDrive-endpoint.service";
import { DocumentResponse } from "../models/documentResponse";
import { documentFile } from "../models/documentFile";
import { DocumentUploadResponse } from "../models/cotnracts/documentUploadResponse";

@Injectable()
export class DockDriveEndpoint {

    constructor(private router: Router, private http: Http, private dockDriveService: DockDriveEndpointService) {

    }


    public UploadDocument(formData: FormData) {
        return this.dockDriveService.UploadDocument(formData).map((response: Response) => <DocumentResponse>response.json());
    }

    // Add Document to the system
    public AddDocument(data: documentFile) {
        return this.dockDriveService.AddDocument(data).map((response: Response) => <DocumentUploadResponse>response.json());
    }

    //Get all available documents
    public GetAllDocuments() {
        return this.dockDriveService.GetAllDocuments().map((response: Response) => { return <DocumentResponse[]>response.json(); });
    }

}