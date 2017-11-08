// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";
import { CustomersComponent } from "./components/customers/customers.component";
import { ProductsComponent } from "./components/products/products.component";
import { OrdersComponent } from "./components/orders/orders.component";
import { SettingsComponent } from "./components/settings/settings.component";
import { AboutComponent } from "./components/about/about.component";
import { NotFoundComponent } from "./components/not-found/not-found.component";
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { BuildingsComponent } from "./components/buildings/buildings.component";
import { BuildingDetailsComponent } from "./components/building-details/building-details.component";
import { ApartamentComponent } from "./components/apartament/apartament.component";
import { BuildingEntrancesComponent } from "./components/buildingEntrances/building-entrances.component";
import { BuildingFloorComponent } from "./components/buildingFloor/building-floor-component";
import { UserRegistrationComponent } from "./components/userregistration/user-registration.component";
import { DocDriveComponent } from "./components/docDrive/docDrive.component";



@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: "", component: HomeComponent, data: { title: "Home" } },
            { path: "login", component: LoginComponent, data: { title: "Login" } },
            { path: "customers", component: CustomersComponent, canActivate: [AuthGuard], data: { title: "Customers" } },
            { path: "products", component: ProductsComponent, canActivate: [AuthGuard], data: { title: "Products" } },
            { path: "orders", component: OrdersComponent, canActivate: [AuthGuard], data: { title: "Orders" } },
            { path: "settings", component: SettingsComponent, canActivate: [AuthGuard], data: { title: "Settings" } },
            { path: "about", component: AboutComponent, data: { title: "About Us" } },
            { path: "home", redirectTo: "/", pathMatch: "full" },
            { path: "buildings/:id", component: BuildingsComponent },
            { path: "buildings", component: BuildingsComponent },
            { path: "building-details/:id", component: BuildingDetailsComponent },
            { path: 'building-apartaments/:id', component: ApartamentComponent },
            { path: 'building-entrance/:id', component: BuildingEntrancesComponent },
            { path: 'building-floor/:id', component: BuildingFloorComponent },
            { path: 'user-registration', component: UserRegistrationComponent },
            { path: 'docdrive', component: DocDriveComponent},
            { path: "**", component: NotFoundComponent, data: { title: "Page Not Found" } },
        ])
    ],
    exports: [
        RouterModule
    ],
    providers: [
        AuthService, AuthGuard
    ]
})
export class AppRoutingModule { }