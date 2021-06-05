import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { store } from "../services/store.service";

@Component({
    selector: "login-page",
    templateUrl: "loginPage.component.html"
})
export class LoginPage{
    constructor(private Store:store, private router: Router) {

    }

    public creds = {
        username: "",
        password: ""
    }

    onLogin() {
        alert("Logging in");
    }
}