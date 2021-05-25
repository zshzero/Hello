import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import ProductListView from 'src/views/productListView.component';
import { store } from './services/store.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductListView
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    store
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
