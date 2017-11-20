import { Injectable, Injector } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ConfigurationService } from './configuration.service';
import { Resources } from "../../ServiceResources";
import { EndpointFactory } from "./endpoint-factory.service";
import { documentFile } from "../models/documentFile";
 

@Injectable()

export class DockDriveEndpointService extends EndpointFactory {

    private readonly _dokDriveUrl: string = this.configurations.baseUrl + "/api/DockDrive/";
    private readonly _documentUpload: string = this.configurations.baseUrl + "/api/DocumentUpload/";

    UploadDocument(formData: FormData): Observable<Response> {
        var properAddress = this._dokDriveUrl;

        let headers = new Headers();
        headers.append('Accept', 'application/json');

        return this.http.post(properAddress, formData, { headers: headers }).map((response: Response) => { return response; });
    }

    //Add document to our system
    AddDocument(data: documentFile): Observable<Response> {
        return this.http.post(this._documentUpload, data).map((response: Response) => { return response; })
    }

    GetAllDocuments(): Observable<Response> {
        return this.http.get(this._documentUpload).map((response: Response) => { return response; })
    }
}