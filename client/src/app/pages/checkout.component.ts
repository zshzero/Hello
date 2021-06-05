import { Component } from "@angular/core";
import { store } from '../services/store.service';

@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {
  constructor(public Store: store) {
  }

  onCheckout() {
    // TODO
    alert("Doing checkout");
  }
}