import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { store } from '../services/store.service';

@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {
  constructor(public Store: store, private router:Router) {
  }

  public errorMessage = "";

  onCheckout() {
    this.errorMessage = "";
    this.Store.checkout().subscribe(() => {
      this.router.navigate(["/"]);
    }, err => {
      this.errorMessage = "Failed to checkout";
    })
  }
}