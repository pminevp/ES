import {  baseResponse } from "./BaseResponse";
import { documentFile } from "../documentFile";

export class DocumentUploadResponse extends baseResponse
{
    public selectedDocument: documentFile;


}