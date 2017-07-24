import { Injectable } from "@angular/core";
import { Building } from "../models/building";

@Injectable()
export class BuildingsEndpointService
{

    public GetAllBuildings() {
        return this.GetStoredBuildings();
    }

    public GetSelectedBuilding(id:number)
    {
        var building = this.GetStoredBuildings().find(x => x.id === id);
        return building;
    }


    private GetStoredBuildings()
    {
        var buildings = new Array<Building>();
        buildings.push(
            { image: "../../assets/images/Buildings/GotseDelchev-214.jpg", name: 'Сграда 1', description: 'малка сграда в центъра на софия', id: 0 },
            { image: "../../assets/images/Buildings/sgrada2.jpg", name: 'Сграда 2', description: 'блок 214 гоце делчев', id: 1 },
            { image: "../../assets/images/Buildings/sgrada3.jpg", name: 'К-с Фонаните', description: 'Комплексът без край', id: 2 }
        );

        return buildings;
    }
}