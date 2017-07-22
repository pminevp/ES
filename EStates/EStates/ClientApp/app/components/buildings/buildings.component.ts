
import { Component } from "@angular/core";

@Component({
    selector: "app-building",
    templateUrl: './buildings.component.html',
    styleUrls: ['./buildings.component.css']
})

export class BuildingsComponent {
    building1 = require("../../assets/images/Buildings/GotseDelchev-214.jpg");
    building2 = require("../../assets/images/Buildings/sgrada2.jpg");
    building3 = require("../../assets/images/Buildings/sgrada3.jpg");
}