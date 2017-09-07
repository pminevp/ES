// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Injectable, Injector } from '@angular/core';
import { Response, ResponseOptions, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/map';
import { EndpointFactory } from "./endpoint-factory.service";
import { ConfigurationService } from "./configuration.service";
import { Notification } from '../models/notification.model';

@Injectable()
export class NotificationEndpoint extends EndpointFactory {

    private readonly _notificationUrl: string = this.configurations.baseUrl + "/api/Notifications/"

    private readonly _notificationUnreaded: string = this._notificationUrl +"ByBuilding/{buildingId}/ByFloor/{floorId}/unread"


    private demoNotifications = [
        {
            "id": 1,
            "header": "Среща на Блока организирана от Домо оправител \"administrator\"",
            "body": "Среща на всички живущи на бл. \"241 вх А\" задействана от домооправител \"administrator\" на 5/28/2017 от 4:54:13 PM часа",
            "isRead": true,
            "isPinned": true,
            "date": "2017-05-28T16:29:13.5877958"
        },
        {
            "id": 2,
            "header": "Събиране на Такса вход",
            "body": "Домооправителя ще започне събирането на такси за входа.",
            "isRead": false,
            "isPinned": false,
            "date": "2017-05-28T19:54:42.4144502"
        },
        {
            "id": 3,
            "header": "Избор на домооправител",
            "body": "Избираме нов домоуправител утре, моля всеки да подготви своя кандидат.",
            "isRead": false,
            "isPinned": false,
            "date": "2017-05-30T11:13:42.4144502"
        }
    ];


    constructor(http: Http, configurations: ConfigurationService, injector: Injector) {
        super(http, configurations, injector);
    }

    getNotificationEndpoint(notificationId: number): Observable<Response> {

        //let notification = this.demoNotifications.find(val => val.id == notificationId);
        //let response: Response;

        //if (notification) {
        //    response = this.createResponse(notification, 200);
        //}
        //else {
        //    response = this.createResponse(null, 404);
        //}

        //return Observable.of(response);

        return this.http.get(this._notificationUrl + notificationId).map((resp: Response) => { return resp; });
    }



    getNotificationsEndpoint(page: number, pageSize: number): Observable<Response> {

        //let notifications = this.demoNotifications;
        //let response = this.createResponse(this.demoNotifications, 200);

        //return Observable.of(response);

       return this.http.get(this._notificationUrl).map((resp: Response) => { return resp;})
    }



    getUnreadNotificationsEndpoint(buildingId:number, floorId: number): Observable<Response> {

        //let unreadNotifications = this.demoNotifications.filter(val => !val.isRead);
        //let response = this.createResponse(unreadNotifications, 200);

        //return Observable.of(response);

        return this.http.get(this._notificationUrl + "ByBuilding/" + buildingId + "/ByFloor/" + floorId + "/unread").map((resp: Response) => { return resp; });
    }



    getNewNotificationsEndpoint(lastNotificationDate?: Date): Observable<Response> {

        //let unreadNotifications = this.demoNotifications;
        //let response = this.createResponse(unreadNotifications, 200);

        //return Observable.of(response);
        return this.http.get(this._notificationUrl).map((resp: Response) => { return resp; })
    }



    getPinUnpinNotificationEndpoint(notificationId: number, isPinned?: boolean, ): Observable<Response> {

        //let notification = this.demoNotifications.find(val => val.id == notificationId);
        //let response: Response;

        //if (notification) {
        //    response = this.createResponse(null, 204);

        //    if (isPinned == null)
        //        isPinned = !notification.isPinned;

        //    notification.isPinned = isPinned;
        //    notification.isRead = true;
        //}
        //else {
        //    response = this.createResponse(null, 404);
        //}

        return this.http.get(this._notificationUrl + notificationId + "pinned/" + isPinned);    
    }


    public notificationResults: Notification[];

    getReadUnreadNotificationEndpoint(notificationIds: number[], isRead: boolean, ): Observable<Response> {

        //for (let notificationId of notificationIds) {

        //    let notification = this.demoNotifications.find(val => val.id == notificationId);

        //    if (notification) {
        //        notification.isRead = isRead;
        //    }
        //}

        //let response = this.createResponse(null, 204);
        //return Observable.of(response);
                

        return this.http.get(this._notificationUrl + notificationIds.toString() + "readable/" + isRead);         
    }



    getDeleteNotificationEndpoint(notificationId: number): Observable<Response> {

        //let notification = this.demoNotifications.find(val => val.id == notificationId);
        //let response: Response;

        //if (notification) {
        //    this.demoNotifications = this.demoNotifications.filter(val => val.id != notificationId)
        //    response = this.createResponse(notification, 200);
        //}
        //else {
        //    response = this.createResponse(null, 404);
        //}

        //return Observable.of(response);

        return this.http.delete(this._notificationUrl + notificationId).map((resp: Response) => { return resp; } );
    }


    AddNotification(notification: Notification): Observable<Response> {
        return this.http.post(this._notificationUrl, notification).map((resp: Response) => { return resp; });
    }

    UpdateNotification(notification: Notification): Observable<Response> {
        console.log(notification);
        return this.http.put(this._notificationUrl, notification).map((resp: Response) => { return resp; });
    }

    private createResponse(body, status: number) {
        return new Response(new ResponseOptions({ body: body, status: status }));
    }
}