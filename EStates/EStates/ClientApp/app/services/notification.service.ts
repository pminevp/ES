﻿// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/interval';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';
import { NotificationEndpoint } from './notification-endpoint.service';
import { Notification } from '../models/notification.model';



@Injectable()
export class NotificationService {

    private lastNotificationDate: Date;
    private _recentNotifications: Notification[];

    get recentNotifications() {
        return this._recentNotifications;
    }

    set recentNotifications(notifications: Notification[]) {
        this._recentNotifications = notifications;
    }



    constructor(private notificationEndpoint: NotificationEndpoint, private authService: AuthService) {

    }


    getNotification(notificationId?: number) {

        //return this.notificationEndpoint.getNotificationEndpoint(notificationId)
        //    .map((response: Response) => Notification.Create(response.json()));

        return this.notificationEndpoint.getNotificationEndpoint(notificationId).map((resp: Response) => <Notification>resp.json());
    }


    getNotifications(page: number, pageSize: number) {

        //return this.notificationEndpoint.getNotificationsEndpoint(page, pageSize)
        //    .map((response: Response) => {
        //        return this.getNotificationsFromResponse(response);
        //    });

        return this.notificationEndpoint.getNotificationsEndpoint(page, pageSize)
            .map((resp: Response) => <Notification[]>resp.json());
    }


    getUnreadNotifications(buildingId: number, floorId: number) {

        //return this.notificationEndpoint.getUnreadNotificationsEndpoint(buildingId, floorId)
        //    .map((response: Response) => this.getNotificationsFromResponse(response));

        return this.notificationEndpoint.getUnreadNotificationsEndpoint(buildingId, floorId)
            .map((resp: Response) => <Notification[]>resp.json());
    }


    getNewNotifications() {
        //return this.notificationEndpoint.getNewNotificationsEndpoint(this.lastNotificationDate)
        //    .map((response: Response) => this.processNewNotificationsFromResponse(response));

        return this.notificationEndpoint.getNotificationsEndpoint(0, 0)
            .map((resp: Response) => <Notification[]>resp.json());
    }


    getNewNotificationsPeriodically() {
        //return Observable.interval(10000)
        //    .startWith(0)
        //    .flatMap(() => {
        //        return this.notificationEndpoint.getNewNotificationsEndpoint(this.lastNotificationDate)
        //            .map((response: Response) => this.processNewNotificationsFromResponse(response));
        //    });

        return this.notificationEndpoint.getNotificationsEndpoint(0, 0)
            .map((resp: Response) => <Notification[]>resp.json());

    }




    pinUnpinNotification(notificationOrNotificationId: number | Notification, isPinned?: boolean): Observable<Response> {

        if (typeof notificationOrNotificationId === 'number' || notificationOrNotificationId instanceof Number) {
            return this.notificationEndpoint.getPinUnpinNotificationEndpoint(<number>notificationOrNotificationId, isPinned);
        }
        else {
            return this.pinUnpinNotification(notificationOrNotificationId.id);
        }
    }


    readUnreadNotification(notificationIds: number[], isRead: boolean): Observable<Response> {

        return this.notificationEndpoint.getReadUnreadNotificationEndpoint(notificationIds, isRead);
    }




    deleteNotification(notificationId: number): Observable<Notification> {

        return this.notificationEndpoint.getDeleteNotificationEndpoint(notificationId)
                                        .map((resp: Response) => <Notification>resp.json());
        //if (typeof notificationOrNotificationId === 'number' || notificationOrNotificationId instanceof Number) { //Todo: Test me if its check is valid
        //    return this.notificationEndpoint.getDeleteNotificationEndpoint(<number>notificationOrNotificationId)
        //        .map((response: Response) => {
        //            this.recentNotifications = this.recentNotifications.filter(n => n.id != notificationOrNotificationId);
        //            return Notification.Create(response.json());
        //        });
        //}
        //else {
        //    return this.deleteNotification(notificationOrNotificationId.id);
        //}
    }


    AddNotification(notification: Notification) {

        return this.notificationEndpoint.AddNotification(notification)
                                        .map((resp: Response) => <Notification>resp.json());
    }

    DeleteNotification(notificaiton: Notification) {
        return this.notificationEndpoint.getDeleteNotificationEndpoint(notificaiton.id)
                                        .map((resp: Response) => <Notification>resp.json());
    }

    UpdateNotificaiton(notification: Notification) {
        return this.notificationEndpoint.UpdateNotification(notification)
                                        .map((resp: Response) => <Notification>resp.json());
    }

    private processNewNotificationsFromResponse(response: Response) {
        let notifications = this.getNotificationsFromResponse(response);

        for (let n of notifications) {
            if (n.date > this.lastNotificationDate)
                this.lastNotificationDate = n.date;
        }

        return notifications;
    }


    private getNotificationsFromResponse(response: Response) {
        let result = response.json()
        let notifications: Notification[] = [];

        for (let i in result) {
            notifications[i] = Notification.Create(result[i]);
        }

        notifications.sort((a, b) => b.date.valueOf() - a.date.valueOf());
        notifications.sort((a, b) => (a.isPinned === b.isPinned) ? 0 : a.isPinned ? -1 : 1);

        this.recentNotifications = notifications;

        return notifications;
    }



    get currentUser() {
        return this.authService.currentUser;
    }
}