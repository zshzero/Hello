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
import { LoginPage } from './pages/loginPage.component';
import { AuthActivator } from './services/authActivator.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProductListView,
    CartView,
    ShopPage,
    Checkout,
    LoginPage
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    router,
    FormsModule
  ],
  providers: [
    store,
    AuthActivator
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
