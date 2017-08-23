
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Apartament } from "../../models/apartament";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { User } from "../../models/user.model";
import { UserToApartament } from "../../models/userToApartament.model";
import { BuildingApartamentEndpoint } from "../../services/buildingApartament-endpoint";
 
 

@Component({
    selector: 'app-buildingDetails',
    templateUrl: './apartament.component.html',
    styleUrls: ['./apartament.component.css']
})

export class ApartamentComponent {

    selectedApartamentId: number;
    selectedApartament: Apartament;
    owners?: Array<User>
    newUser: User;
    newUserToApart: UserToApartament;

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingsEndpointService, private buildingsApartamentEndpoint: BuildingApartamentEndpoint) {

        var id = route.snapshot.params['id'];
        this.newUser = new User();
        this.newUserToApart = new UserToApartament();

        if (id === undefined) {
        }
        else {
            this.selectedApartamentId = id;
            this.selectedApartament = buildingsEndpoint.GetSelectedApartament(id);

            

            console.log(this.owners);
        }
    }


    Save() {

        console.log(this.newUser.userName);
        this.newUserToApart.apartamentId = this.selectedApartamentId;
        this.newUserToApart.UserName = this.newUser.userName;

        this.buildingsApartamentEndpoint.AddUserToApartament(this.newUserToApart).subscribe(usr => {            

            if (usr.id === "") {
                alert("Невалиден потребител, моля напишете името наново.")
            }
            else
            {
                this.newUser = usr;
                this.owners.push(usr);                  
            }              

        });
        console.log(this.newUser);     
        this.newUser = new User();
    }

}