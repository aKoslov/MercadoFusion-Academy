import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShoppingComponent } from './components/shopping/shopping.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { CartComponent } from './components/shopping/cart/cart.component';
import { FiltersComponent } from './components/shopping/filters/filters.component';
import { ProductsListComponent } from './components/shopping/products-list/products-list.component';
import { CartItemComponent } from './components/shopping/cart/cart-item/cart-item.component';
import { ProductListItemComponent } from './components/shopping/products-list/product-item/product-item.component';

@NgModule({
  declarations: [
    AppComponent,
    ShoppingComponent,
    NavComponent,
    FooterComponent,
    HeaderComponent,
    CartComponent,
    FiltersComponent,
    ProductsListComponent,
    CartItemComponent,
    ProductListItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
