import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import ProductListView from 'src/views/productListView.component';
import CartView from 'src/views/cartView.component';
import { store } from './services/store.service';
import router from './router';
import { ShopPage } from './pages/shopPage.component';
import { Checkout } from './pages/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListView,
    CartView,
    ShopPage,
    Checkout
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    router
  ],
  providers: [
    store
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
