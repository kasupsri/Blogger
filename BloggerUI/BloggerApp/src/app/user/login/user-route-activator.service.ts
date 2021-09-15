import { Router, CanActivate, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";

@Injectable()
export class UserRouteActivator implements CanActivate {
    constructor(private router: Router) {

    }

    canActivate(route:ActivatedRouteSnapshot) {
        var result =false
        var localUser = localStorage.getItem("user");
        if (localUser) {
            var user = JSON.parse(localUser);
            if (!(user.id > 0)) {
                this.router.navigate(["/login"])
            }
            else
            {
                result=true
            }
        }
        else {
            this.router.navigate(["/login"])
        }

        return result
    }
}