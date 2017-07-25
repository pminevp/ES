
import { Component, OnInit } from "@angular/core";
import { Building } from "../../models/building";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { BuildingsEndpointService } from "../../services/buildings-endpoint.service";

@Component({
    selector: "app-building",
    templateUrl: './buildings.component.html',
    styleUrls: ['./buildings.component.css']
})

export class BuildingsComponent {
       
     buildings: Array<Building>;
     newBuilding: Building = new Building();
    selectedBuildingId:number

    constructor(private route: ActivatedRoute, private buildingsEndpoint: BuildingsEndpointService) {
        //this.buildings = new Array<Building>();
        //this.buildings.push(
        //    { image: require("../../assets/images/Buildings/GotseDelchev-214.jpg"), name: 'Сграда 1', description: 'малка сграда в центъра на софия', id:0 },
        //    { image: require("../../assets/images/Buildings/sgrada2.jpg"), name: 'Сграда 2', description: 'блок 214 гоце делчев', id: 1 },
        //    { image: require("../../assets/images/Buildings/sgrada3.jpg"), name: 'К-с Фонаните', description: 'Комплексът без край', id:2 }
        //);

        this.buildings = buildingsEndpoint.GetAllBuildings().map(function (x) {

            
            return x;
        });

        var id = route.snapshot.params['id'];
        if (id === undefined)
        {
            console.log('is unidentified');
        }
        else
        {
            this.selectedBuildingId = id;
        }
     }

    public Save(){
        
        console.log(this.newBuilding.name);
        this.buildings.push(this.newBuilding);
        this.newBuilding = new Building();
     }

    public GetSelectedBuilding()
    {
        if (this.selectedBuildingId === undefined)
            return new Building()
        else
            return this.buildings.find(x => x.id === this.selectedBuildingId);
    }

    private AddId(id: number) : Promise<number>
    {
        console.log(id);
        this.selectedBuildingId = id;
        return new Promise<number>(x => this.selectedBuildingId);
    }
}