import { Component, OnInit, OnDestroy, TemplateRef, ViewChild, Input } from '@angular/core';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from "../../services/app-translation.service";
import { NotificationService } from "../../services/notification.service";
import { AccountService } from "../../services/account.service";
import { Permission } from '../../models/permission.model';
import { Utilities } from "../../services/utilities";
import { Notification } from '../../models/notification.model';
import { ModalDirective } from "ngx-bootstrap/modal";
import { Building } from "../../models/building";
import { BuildingService } from "../../services/BuildingService";
import { BuildingApartamentEndpoint } from "../../services/buildingApartament-endpoint";
import { Apartament } from "../../models/apartament";
import { BuildingEntrance } from "../../models/buildingEntrance";
import { BuildingEntranceEndpoint } from "../../services/buildingEntrance-endpoint";
import { BuildingFloorService } from "../../services/BuildingFloor.service";
import { BuildingFloor } from "../../models/buildingFloor";

@Component({
    selector: 'notifications-viewer',
    templateUrl: './notifications-viewer.component.html',
    styleUrls: ['./notifications-viewer.component.css']
})
export class NotificationsViewerComponent implements OnInit, OnDestroy {
    columns: any[] = [];
    rowsChached: Notification[];
    rows: Notification[];
    loadingIndicator: boolean;
    formResetToggle: boolean = true;
    newNotification: Notification;
    buildings: Building[];
    buildingEntrances: BuildingEntrance[];
    buildingFloors: BuildingFloor[];

    selectedBuilding: Building;
    selectedFloor: BuildingFloor;

    availableApartaments: Apartament[];

    dataLoadingConsecutiveFailurs = 0;
    dataLoadingSubscription: any;


    @Input()
    isViewOnly: boolean;

    @Input()
    verticalScrollbar: boolean = false;


    @ViewChild('statusHeaderTemplate')
    statusHeaderTemplate: TemplateRef<any>;

    @ViewChild('statusTemplate')
    statusTemplate: TemplateRef<any>;

    @ViewChild('dateTemplate')
    dateTemplate: TemplateRef<any>;

    @ViewChild('contentHeaderTemplate')
    contentHeaderTemplate: TemplateRef<any>;

    @ViewChild('contenBodytTemplate')
    contenBodytTemplate: TemplateRef<any>;

    @ViewChild('actionsTemplate')
    actionsTemplate: TemplateRef<any>;

    @ViewChild('editorModal')
    editorModal: ModalDirective;

    constructor(private alertService: AlertService, private translationService: AppTranslationService, private accountService: AccountService, private notificationService: NotificationService, private buildingService: BuildingService, private apartamentEndpoint: BuildingApartamentEndpoint, private buildingEntranceEndpoint: BuildingEntranceEndpoint, private buildingFloorEndpoint: BuildingFloorService) {

        this.newNotification = new Notification();
    }


    ngOnInit() {

        if (this.isViewOnly) {
            this.columns = [
                { prop: 'date', cellTemplate: this.dateTemplate, width: 100, resizeable: false, canAutoResize: false, sortable: false, draggable: false },
                { prop: 'body', cellTemplate: this.contentHeaderTemplate, width: 200, resizeable: false, sortable: false, draggable: false },
            ];
        }
        else {
            let gT = (key: string) => this.translationService.getTranslation(key);

            this.columns = [
                { prop: "", name: '', width: 10, headerTemplate: this.statusHeaderTemplate, cellTemplate: this.statusTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false },
                { prop: 'date', name: 'Дата', cellTemplate: this.dateTemplate, width: 30 },
                { prop: 'header', name: 'Съобщение', cellTemplate: this.contenBodytTemplate, width: 500 },
                { name: '', width: 80, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false }
            ];
        }


        this.initDataLoading();
    }


    ngOnDestroy() {
        if (this.dataLoadingSubscription)
            this.dataLoadingSubscription.unsubscribe();
    }



    initDataLoading() {

        if (this.isViewOnly && this.notificationService.recentNotifications) {
            this.rows = this.processResults(this.notificationService.recentNotifications);
            return;
        }


        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        let dataLoadTask = this.isViewOnly ? this.notificationService.getNewNotifications() : this.notificationService.getNewNotificationsPeriodically()

        this.dataLoadingSubscription = dataLoadTask
            .subscribe(notifications => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;
                this.dataLoadingConsecutiveFailurs = 0;

                this.rows = this.processResults(notifications);
                this.rowsChached = this.rows;
            },
            error => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.alertService.showMessage("Load Error", "Loading new notifications from the server failed!", MessageSeverity.warn);
                this.alertService.logError(error);

                if (this.dataLoadingConsecutiveFailurs++ < 5)
                    setTimeout(() => this.initDataLoading(), 5000);
                else
                    this.alertService.showStickyMessage("Load Error", "Loading new notifications from the server failed!", MessageSeverity.error);

            });


        if (this.isViewOnly)
            this.dataLoadingSubscription = null;

        if (this.accountService.userHasPermission(Permission.AssignBuildingsPermission)) {

            this.buildingService.GetAllBuildings().subscribe(
                blds => {

                    var systemBuilding = new Building();
                    systemBuilding.id = 0;
                    systemBuilding.name="За Всички блокове"

                    this.buildings = blds;
                    this.buildings.push(systemBuilding);              
                },
                wrr => { console.log(wrr); });
        }
        else
        {               
                      
            this.buildingService.GetBuildingByOwner(this.accountService.currentUser.id).subscribe(
                bld => {
                    this.selectedBuilding = bld;
                    this.loadEntrances(bld.id);
                }
            );
          
        }
    }


    public loadEntrances(buildingId: number) {

        this.buildingEntrances = null;
        var selectedBuilding: Building;

        if (this.buildings != null) {
            selectedBuilding = this.buildings.find(x => x.id == buildingId);
        }
        else {
            if (this.selectedBuilding != null) {
                selectedBuilding = this.selectedBuilding;
            }
        }        

        if (selectedBuilding.id != 0) {
            

            this.buildingEntranceEndpoint.GetEntrancesByBuildingId(buildingId).subscribe(
                entrances => {

                    var systemEntrance = new BuildingEntrance();
                    systemEntrance.id = 0;
                    systemEntrance.name = "Всички входове";

                    this.buildingEntrances = entrances;
                    this.buildingEntrances.push(systemEntrance);
                },
                err => console.log(err)
            );
        }
    }

    public loadFloors(entranceId: number) {
        this.buildingFloors = null;
        console.log(entranceId);
        if (entranceId != 0) {
            console.log(entranceId);
            this.buildingFloorEndpoint.GetFloorsByEntranceId(entranceId).subscribe(
                floors => {

                    this.buildingFloors = floors;
                    var sysFloor = new BuildingFloor();
                    sysFloor.id = 0;
                    sysFloor.name = "Всички Етажи";
                    this.buildingFloors.push(sysFloor);
                }
            );
        }
    }


    private processResults(notifications: Notification[]) {

        if (this.isViewOnly) {
            notifications.sort((a, b) => {
                return b.date.valueOf() - a.date.valueOf();
            });
        }

        return notifications;
    }



    getPrintedDate(value: Date) {
        if (value)
            return Utilities.printTimeOnly(value) + " on " + Utilities.printDateOnly(value);
    }


    deleteNotification(row: Notification) {
        this.alertService.showDialog('Желаете ли да изтриете \"' + row.header + '\"?', DialogType.confirm, () => this.deleteNotificationHelper(row));
    }


    deleteNotificationHelper(row: Notification) {

        this.alertService.startLoadingMessage("Изтриване на съобщение...");
        this.loadingIndicator = true;

        this.notificationService.deleteNotification(row.id)
            .subscribe(results => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.rows = this.rows.filter(item => item.id != row.id)
            },
            error => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.alertService.showStickyMessage("Грешка!", `Съобщението неможе да бъде изтрито.`,
                    MessageSeverity.error, error);
            });
    }


    togglePin(row: Notification) {

        let pin = !row.isPinned;
        let opText = pin ? "Pinning" : "Unpinning";

        this.alertService.startLoadingMessage(opText + "...");
        this.loadingIndicator = true;

        this.notificationService.pinUnpinNotification(row, pin)
            .subscribe(results => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                row.isPinned = pin;
            },
            error => {
                this.alertService.stopLoadingMessage();
                this.loadingIndicator = false;

                this.alertService.showStickyMessage(opText + " Error", `An error occured whilst ${opText} the notification.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
                    MessageSeverity.error, error);
            });
    }


    get canManageNotifications() {
        return this.accountService.userHasPermission(Permission.manageRolesPermission); //Todo: Consider creating separate permission for notifications
    }


    isEditMode: Boolean;
    taskEdit = {};


    save() {

        var currentDate = new Date();
        this.newNotification.date = currentDate;
        this.newNotification.ownerId = this.accountService.currentUser.id;

        if (this.selectedBuilding != null) {
            this.newNotification.buildingId = this.selectedBuilding.id;
        }

        this.notificationService.AddNotification(this.newNotification).subscribe(

            obj => {

                if (obj.id != 0) {
                    this.rowsChached.push(obj);
                    this.newNotification = new Notification();
                    this.buildingFloors = null;
                    this.buildingEntrances = null;
                }
            },
            err => {
                this.alertService.showMessage("Проблем при записване!", "Проблем при записването на ново съобщение.", MessageSeverity.error);
                console.log(err);
            }
        );

        this.editorModal.hide();
    }

    update() {

        this.notificationService.UpdateNotificaiton(this.newNotification).subscribe(

            obj => {

                this.alertService.showMessage("Успешна редкация!", "Промените бяха успешно запазени.", MessageSeverity.success);
                this.editorModal.hide();
                this.newNotification = new Notification();
            },
            err => {
                this.alertService.showMessage("Проблем при записване!", "Проблем при записването на ново съобщение.", MessageSeverity.error);
                console.log(err);
            }
        );
    }

    addTask() {
        this.isEditMode = false;
        this.formResetToggle = false;

        setTimeout(() => {
            this.formResetToggle = true;

            this.taskEdit = {};
            this.editorModal.show();
        });
    }

    showErrorAlert(caption: string, message: string) {
        this.alertService.showMessage(caption, message, MessageSeverity.error);
    }

    onSearchChanged(value: string) {
        if (value) {
            value = value.toLowerCase();

            console.log(this.rows);
            let filteredRows = this.rowsChached.filter(r => {
                let isChosen = !value
                    || r.header.toLowerCase().indexOf(value) !== -1

                return isChosen;
            });

            this.rows = filteredRows;
        }
        else {
            this.rows = [...this.rowsChached];
        }
    }


    onShowNotification(id: number) {

    

        this.isEditMode = true;
        var notification = this.rowsChached.find(x => x.id == id);

        if (notification.buildingId != 0 )
            this.loadEntrances(notification.buildingId);
        else
            this.buildingEntrances = null;

        if (notification.buildingEntranceId != 0 )
            this.loadFloors(notification.buildingEntranceId);
        else
            this.buildingFloors = null;

        console.log(notification);

        this.newNotification = notification;
        this.editorModal.show();
    }

}
