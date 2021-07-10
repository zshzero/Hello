import { Component } from "@angular/core";
import { store } from "../app/services/store.service"

@Component({
    selector : "cart",
    templateUrl : "./cartView.component.html"
})
export default class cartView {
    constructor(public Store: store) {

    }
}