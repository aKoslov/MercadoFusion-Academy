import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { ShoppingComponent } from './components/shopping/shopping.component';
import { FiltersComponent } from './components/shopping/filters/filters.component';
import { CartComponent } from './components/shopping/cart/cart.component';
import { ProductsListComponent } from './components/shopping/products-list/products-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    FooterComponent,
    HeaderComponent,
    ShoppingComponent,
    FiltersComponent,
    CartComponent,
    ProductsListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
