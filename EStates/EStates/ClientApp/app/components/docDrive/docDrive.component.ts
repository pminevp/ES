import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { AlertService, MessageSeverity } from "../../services/alert.service";
import { Permission } from "../../models/permission.model";
import { AccountService } from "../../services/account.service";
import { DockDriveEndpoint } from "../../services/DockDrive-endpoint";
import { documentFile } from "../../models/documentFile";
import { DocumentResponse } from "../../models/documentResponse";

@Component({
    selector: "app-docDrive",
    templateUrl: './docDrive.component.html',
    styleUrls: ['./docDrive.component.css']
})


export class DocDriveComponent implements OnInit {

    public newUploadedDocument: documentFile;
    private documentResponse: DocumentResponse;
    private documentTypeId: number;

    ngOnInit(): void {

    }

    constructor(private dockDriveEndpoint: DockDriveEndpoint) {

        this.newUploadedDocument = new documentFile();
    }


    fileChange(event) {

        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            formData.append('test', 'bigTest');

            this.dockDriveEndpoint.UploadDocument(formData).subscribe(data => this.onDocumentUpload(data), error => console.log(error));
        }
    }

    Save() {

        this.newUploadedDocument.typeId = this.documentTypeId;
        this.newUploadedDocument.buildingFloorId = 0;
        this.newUploadedDocument.buildingId = 0;
        
        console.log(this.newUploadedDocument);
        this.dockDriveEndpoint.AddDocument(this.newUploadedDocument).subscribe(
            response => console.log(response),
            error => console.log(error)
        );
    }

    selectedDocument(typeId: number) {
        this.documentTypeId = typeId;
    }

    onDocumentUpload(data: DocumentResponse) {

        this.newUploadedDocument.webPath = data.documentWebPath;
        this.newUploadedDocument.documentName = data.documentFileName;
    }
}