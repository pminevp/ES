import { Injectable, OnInit } from "@angular/core";
import { Http, Response, Headers, ResponseOptions } from '@angular/http';
import { Building } from "../models/building";
import { Apartament } from "../models/apartament";
import { ApartamentStatuses } from "../models/apartamentStatuses";
import { User } from "../models/user.model";
import { Resources } from "../../ServiceResources";
import { Observable } from 'rxjs/Rx';
import { Subject } from "rxjs/Subject";

@Injectable()
export class BuildingsEndpointService implements OnInit {


    buildServices: BuildingService;

    constructor(private _http: Http) {
        console.log('dsa');
        let endpointUrl = Resources.BuildingPath;

        this._http.get(endpointUrl)
            .map((response: Response) => {
                return response;
            }).map((response: Response) => <Building>response.json()).subscribe(user => this.onCurrentBuildingsLoadSuccessful(user));

  
    }


    ngOnInit() {

        console.log('dsa');
        let endpointUrl = Resources.BuildingPath;

        this._http.get(endpointUrl)
            .map((response: Response) => {
                return response;
            }).map((response: Response) => <Building>response.json()).subscribe(user => this.onCurrentBuildingsLoadSuccessful(user));

       //this.buildServices = new BuildingService(this._http);
       // this.buildServices.getAllTest2().subscribe(user => this.onCurrentBuildingsLoadSuccessful(user));
    }


    public GetAllBuildings() {
        return this.GetStoredBuildings();
    }

    public GetSelectedBuilding(id: number): Building {
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

        this.GetAllBuildingsService();
        buildings.push(
            { image: "../../assets/images/Buildings/GotseDelchev-214.jpg", name: 'Сграда 1', description: 'малка сграда в центъра на софия', id: 0 },
            { image: "../../assets/images/Buildings/sgrada2.jpg", name: 'Сграда 2', description: 'блок 214 гоце делчев', id: 1 },
            { image: "../../assets/images/Buildings/sgrada3.jpg", name: 'К-с Фонаните', description: 'Комплексът без край', id: 2 }
        );

        //buildings.push(
        //    { image: "../../assets/images/Buildings/GotseDelchev-214.jpg", name: 'Сграда 1', description: 'малка сграда в центъра на софия', id: 0, apartaments: new Array<Apartament>() },
        //    { image: "../../assets/images/Buildings/sgrada2.jpg", name: 'Сграда 2', description: 'блок 214 гоце делчев', id: 1, apartaments: new Array<Apartament>() },
        //    { image: "../../assets/images/Buildings/sgrada3.jpg", name: 'К-с Фонаните', description: 'Комплексът без край', id: 2, apartaments: new Array<Apartament>() }
        //);


        for (var i = 0; i < buildings.length; i++) {

            var building = buildings[i];
            building = this.PopulateApartaments(building);
        }

        return buildings;
    }


    private PopulateApartaments(building: Building) {
        var apartStatuses = new ApartamentStatuses();
        //building.apartaments.push(
        //    { id: 0, name: 'Ап 1 ет 1', description: 'апартамент на сем. Иванови', owners: 'сем. Иванови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
        //    { id: 1, name: 'Ап 2 ет 1', description: 'апартамент на сем. Тодорови', owners: 'сем. Тодорови', status: apartStatuses.UnpaidBills, owner: this.GetApartamentOwners() },
        //    { id: 2, name: 'Ап 3 ет 1', description: 'апартамент на сем. Кирови', owners: 'сем. Кирови', status: apartStatuses.Question, owner: this.GetApartamentOwners() },
        //    { id: 3, name: 'Ап 4 ет 2', description: 'апартамент на сем. Симеонови', owners: 'сем. Симеонови', status: apartStatuses.Important, owner: this.GetApartamentOwners() },
        //    { id: 4, name: 'Ап 5 ет 2', description: 'апартамент на сем. Кичукови', owners: 'сем. Кичукови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
        //);
        return building;
    }

    private GetApartaments() {
        var apartStatuses = new ApartamentStatuses();
        var aarr = new Array<Apartament>();
        //aarr.push({ id: 0, name: 'Ап 1 ет 1', description: 'апартамент на сем. Иванови', owners: 'сем. Иванови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() },
        //    { id: 1, name: 'Ап 2 ет 1', description: 'апартамент на сем. Тодорови', owners: 'сем. Тодорови', status: apartStatuses.UnpaidBills, owner: this.GetApartamentOwners() },
        //    { id: 2, name: 'Ап 3 ет 1', description: 'апартамент на сем. Кирови', owners: 'сем. Кирови', status: apartStatuses.Question, owner: this.GetApartamentOwners() },
        //    { id: 3, name: 'Ап 4 ет 2', description: 'апартамент на сем. Симеонови', owners: 'сем. Симеонови', status: apartStatuses.Important, owner: this.GetApartamentOwners() },
        //    { id: 4, name: 'Ап 5 ет 2', description: 'апартамент на сем. Кичукови', owners: 'сем. Кичукови', status: apartStatuses.Normal, owner: this.GetApartamentOwners() });

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

    buildings: Building;


    private GetAllBuildingsService() {

        console.log('t');
        console.log(this.buildings);

        //var t = this.$http.get(buildingURL).subscribe(x=>this.GetData(x));
    }

    public test: any;

    private GetData(response: any) {
        console.log(' the response');
        console.log(response._body);

        let bld: Building = JSON.parse(response._body);


    }

    getDataObservable(url: string) {
        return this._http.get(url)
            .map(data => {
                data.json();
                return data.json();
            });
    }

    private onCurrentBuildingsLoadSuccessful(building: Building) {


        console.log('starting');

        this.buildings = building;     

        console.log(this.buildings);
    }

}


class BuildingService {

    constructor(private _http: Http) {

    }

    getAllTest2() {

        return this.GetAllTest().map((response: Response) => <Building>response.json());
    }

    GetAllTest(): Observable<Response> {
        let endpointUrl = Resources.BuildingPath;

        return this._http.get(endpointUrl)
            .map((response: Response) => {
                return response;
            })
    }


    //public GetAllTest(): Observable<any>
    //{
    //    return this._http.get(Resources.BuildingPath)
    //        .map((res: Response) => res.json())
    //        .catch((error: any) => Observable.throw(error.json()));
    //}

    public GetAll(): any {
        var response = this.GetData(Resources.BuildingPath);
        //  let bld = JSON.parse(response._body); 



        return response;
    }

    public GetById(id: number): any {

        var properUrl = Resources.BuildingPath + id;

        //var response = this.GetData(properUrl);
        //  let bld: Building = JSON.parse(response._body);
    }


    private GetData(url: string): any {
        var resp: any;
        console.log('GetData');
        //var a =   this._http.get(url).subscribe(result =>this.ConsumeResponse(result));

        //this._http.get(url).subscribe((result: any) => {

        //    console.log('With Subscripbe');
        //    var resultSet = result._body;

        //    console.log(resultSet);
        //});


        var s: any;
        var obs = this._http.get(url).map(x => {

            s = x;

            return x;
        });


        console.log(obs.take(0));
        console.log(s);


        return resp;
    }



}