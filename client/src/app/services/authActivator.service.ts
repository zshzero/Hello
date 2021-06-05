import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { store } from "./store.service";

@Injectable()
export class AuthActivator implements CanActivate {

    constructor(private Store: store, private Router: Router){
        
    }

    canActivate(route: ActivatedRouteSnapshot, 
                state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if(this.Store.loginRequired){
            this.Router.navigate(["login"])
            return false;
        } else {
            return true;
        }
    }
}