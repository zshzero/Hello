import { Component, OnInit } from "@angular/core";
import { store } from "../app/services/store.service"

@Component({
    selector : "product-list",
    templateUrl : "./productListView.component.html"
})
export default class ProductListView implements OnInit {
    constructor(public Store: store) {
    }

    ngOnInit(): void {
        this.Store.loadProducts()
                .subscribe();
    }
}