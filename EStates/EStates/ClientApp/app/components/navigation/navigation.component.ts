
import { Component } from "@angular/core";
import { OnInit } from "@angular/core";
import { AuthService } from "../../services/auth.service";
import { NavigationLink } from "../../models/navigationLink";
import { Router, NavigationStart } from "@angular/router";
import { AccountService } from "../../services/account.service";


@Component({
    selector: "app-navigation",
    templateUrl: './navigation.component.html',
    styleUrls: ['./navigation.component.css']
})
 
export class NavigationComponent implements OnInit{

    isUserLoggedIn: boolean;
    userName: string;
    navigations: Array<NavigationLink>;

    constructor(private router: Router, private authService: AuthService, private accountService: AccountService) {
        this.loadAuthenticatedMenuItems();
    }

    ngOnInit()
    {        
        this.isUserLoggedIn = this.authService.isLoggedIn;

        if (this.isUserLoggedIn)
        {
            this.userName = this.authService.currentUser.userName;         
        }

        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                let url = (<NavigationStart>event).url;

                if (url !== url.toLowerCase()) {
                    this.router.navigateByUrl((<NavigationStart>event).url.toLowerCase());
                }
            }
        });
               
    }


    public RefreashMenu()
    {
        this.loadAuthenticatedMenuItems();
    }

    private loadAuthenticatedMenuItems() {

        this.navigations = new Array<NavigationLink>();
        var allnavigations = this.loadMenuItems();
        var acc = this.accountService.currentUser;
        console.log(acc);

        var defaultGroup = "users.view";

        if (acc === null)
        {
            this.navigations = allnavigations.filter(x => x.name == defaultGroup);
            return;
        }
        else
        {
            this.navigations = new Array<NavigationLink>();
            var userPermissions = this.authService.userPermissions; 

            for (var i = 0; i < userPermissions.length; i++) {   

                var permissionValue = this.accountService.GetUsersPermissionValuesByRole(userPermissions[i]);
                if (permissionValue != null)
                {                    
                    var groups = allnavigations.filter(x => x.name == permissionValue);
                    if (groups != undefined && groups != null)
                    {
                        console.log(groups);
                        this.navigations = this.navigations.concat(groups);
                    }                  
                }
              
            }  
          
        }
    }

    private loadMenuItems(): Array<NavigationLink>{
              

        var localNavigation = new Array<NavigationLink>();
        localNavigation.push({ text: "Начало", route: "/", name:"users.view",id:1 });
        localNavigation.push({ text: "Наши Клиенти", route: "/", name: "users.view", id: 2 });
        localNavigation.push({ text: "Сгради", route: "/buildings", name: "buildings.view", id: 3 });
        localNavigation.push({ text: "Апартаменти", route: "/", name: "apartaments.view", id: 4 });
        localNavigation.push({ text: "За Нас", route: "/", name: "users.view", id: 5 });

        return localNavigation;
    }
}