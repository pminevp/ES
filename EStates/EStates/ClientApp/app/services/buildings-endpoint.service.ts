import { Injectable } from "@angular/core";
import { Building } from "../models/building";
import { Apartament } from "../models/apartament";
import { ApartamentStatuses } from "../models/apartamentStatuses";
import { User } from "../models/user.model";

@Injectable()
export class BuildingsEndpointService {

    public GetAllBuildings() {
        return this.GetStoredBuildings();
    }

    public GetSelectedBuilding(id: number) : Building {
        var loadedBuildings = this.GetStoredBuildings();

        var localBuilding;

        for (var i = 0; i < loadedBuildings.length; i++) {

            if (loadedBuildings[i].id == id) {
                localBuilding = loadedBuildings[i];

                break;
            }
        }

        return localBuilding;
    }

    public GetSelectedApartament(id: number) {
        var selectedApart = new Apartament();
        var arr = this.GetApartaments();

        for (var i = 0; i < arr.length; i++) {

            if (arr[i].id == id) {
                selectedApart = arr[i];
                break;
            }
        }

        return selectedApart;
    }

    private GetStoredBuildings() {
        var buildings = new Array<Building>();
        buildings.push(
            { image: "../../assets/images/Buildings/GotseDelchev-214.jpg", name: 'Сграда 1', description: 'малка сграда в центъра на софия', id: 0, apartaments: new Array<Apartament>() },
            { image: "../../assets/images/Buildings/sgrada2.jpg", name: 'Сграда 2', description: 'блок 214 гоце делчев', id: 1, apartaments: new Array<Apartament>() },
            { image: "../../assets/images/Buildings/sgrada3.jpg", name: 'К-с Фонаните', description: 'Комплексът без край', id: 2, apartaments: new Array<Apartament>() }
        );


        for (var i = 0; i < buildings.length; i++) {

            var building = buildings[i];
            building = this.PopulateApartaments(building);
        }

        return buildings;
    }


    private PopulateApartaments(building: Building) {
        var apartStatuses = new ApartamentStatuses();
        building.apartaments.push(
            { id: 0, name: 'Ап 1 ет 1', description: 'апартамент на сем. Иванови', owners: 'сем. Иванови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
            { id: 1, name: 'Ап 2 ет 1', description: 'апартамент на сем. Тодорови', owners: 'сем. Тодорови', status: apartStatuses.UnpaidBills, owner: this.GetApartamentOwners() },
            { id: 2, name: 'Ап 3 ет 1', description: 'апартамент на сем. Кирови', owners: 'сем. Кирови', status: apartStatuses.Question, owner: this.GetApartamentOwners() },
            { id: 3, name: 'Ап 4 ет 2', description: 'апартамент на сем. Симеонови', owners: 'сем. Симеонови', status: apartStatuses.Important, owner: this.GetApartamentOwners() },
            { id: 4, name: 'Ап 5 ет 2', description: 'апартамент на сем. Кичукови', owners: 'сем. Кичукови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
        );
        return building;
    }

    private GetApartaments() {
        var apartStatuses = new ApartamentStatuses();
        var aarr = new Array<Apartament>();
        aarr.push({ id: 0, name: 'Ап 1 ет 1', description: 'апартамент на сем. Иванови', owners: 'сем. Иванови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
            { id: 1, name: 'Ап 2 ет 1', description: 'апартамент на сем. Тодорови', owners: 'сем. Тодорови', status: apartStatuses.UnpaidBills, owner: this.GetApartamentOwners() },
            { id: 2, name: 'Ап 3 ет 1', description: 'апартамент на сем. Кирови', owners: 'сем. Кирови', status: apartStatuses.Question, owner: this.GetApartamentOwners() },
            { id: 3, name: 'Ап 4 ет 2', description: 'апартамент на сем. Симеонови', owners: 'сем. Симеонови', status: apartStatuses.Important, owner: this.GetApartamentOwners() },
            { id: 4, name: 'Ап 5 ет 2', description: 'апартамент на сем. Кичукови', owners: 'сем. Кичукови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() });

        return aarr;
    }

    private GetApartamentOwners() {

        var usr1 = new User('1', 'usr1', 'name', 'usr@abv.bg', 'jbTits', '111');
        var usr2 = new User('2', 'usr2', 'aa', 'usr@abv.bg', 'jbTits', '111');
        var usr3 = new User('3', 'usr3', 'nzaaa', 'usr@abv.bg', 'jbTits', '111');

        var usrs = new Array<User>();
        usrs.push(usr1);
        usrs.push(usr2);
        usrs.push(usr3);

        return usrs;
    }
}