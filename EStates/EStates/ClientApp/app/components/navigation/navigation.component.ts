
import { Component } from "@angular/core";
import { OnInit } from "@angular/core";
import { AuthService } from "../../services/auth.service";
import { NavigationLink } from "../../models/navigationLink";
import { Router, NavigationStart } from "@angular/router";


@Component({
    selector: "app-navigation",
    templateUrl: './navigation.component.html',
    styleUrls: ['./navigation.component.css']
})
 
export class NavigationComponent implements OnInit{

    isUserLoggedIn: boolean;
    navigations: NavigationLink[];

    constructor(private router: Router, private authService: AuthService) {
        this.loadMenuItems();
    }

    ngOnInit()
    {        
        this.isUserLoggedIn = this.authService.isLoggedIn;
        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                let url = (<NavigationStart>event).url;

                if (url !== url.toLowerCase()) {
                    this.router.navigateByUrl((<NavigationStart>event).url.toLowerCase());
                }
            }
        });
    }

    private loadMenuItems(): void{

        this.navigations = new Array<NavigationLink>();
        this.navigations.push({ text: "Начало", route: "/" });
        this.navigations.push({ text: "Наши Клиенти", route: "/" });
        this.navigations.push({ text: "Сгради", route: "/" });
        this.navigations.push({ text: "Апартаменти", route: "/" });
        this.navigations.push({ text: "За Нас", route: "/" });
    }
}