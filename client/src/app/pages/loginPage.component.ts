import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { store } from "../services/store.service";
import { LoginRequest } from "../shared/LoginResults";

@Component({
    selector: "login-page",
    templateUrl: "loginPage.component.html"
})
export class LoginPage{
    constructor(private Store:store, private router: Router) {

    }
    
    public creds: LoginRequest = {
        username: "",
        password: ""
    }

    public errorMessage = ""

    onLogin() {
        this.Store.login(this.creds)
            .subscribe(() => {
                if(this.Store.order.items.length > 0) {
                    this.router.navigate(["checkout"]);
                } else {
                    this.router.navigate([""]);
                }
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to Login";
            });
    }
}