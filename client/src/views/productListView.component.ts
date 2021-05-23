import { Component } from "@angular/core";

@Component({
    selector : "product-list",
    templateUrl : "./productListView.component.html"
})
export default class ProductListView {
    public products = [
        {
            title: "Not sure if its a Painting",
            price: "199.99" 
        },
        {
            title: "Its sort of Painting",
            price: "19.99" 
        }
    ];
}