
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Apartament } from "../../models/apartament";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";
import { User } from "../../models/user.model";

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

    constructor(route: ActivatedRoute, private buildingsEndpoint: BuildingsEndpointService) {

        var id = route.snapshot.params['id'];
        this.newUser = new User();

        if (id === undefined) {
        }
        else {
            this.selectedApartamentId = id;
            this.selectedApartament = buildingsEndpoint.GetSelectedApartament(id);

            if (this.selectedApartament.owners === undefined) {

            }
            else {
                this.owners = this.selectedApartament.owner;
            }

            console.log(this.owners);
        }
    }


    Save() {
        console.log(this.newUser);
        this.selectedApartament.owner.push(this.newUser);
        this.newUser = new User();
    }

}