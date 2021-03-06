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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountComponent } from './components/users/account/account.component';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { SignupComponent } from './components/users/signup/signup.component';
import { LoginComponent } from './components/users/login/login.component';
import { OrderComponent } from './components/order-list/order/order.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { OrderItemComponent } from './components/order-list/order/order-item/order-item.component';
import { CheckoutComponent } from './components/shopping/checkout/checkout.component';
import { SuccessPopUpComponent } from './components/shared/success-pop-up/success-pop-up.component';
import { UserInfoComponent } from './components/users/user-info/user-info.component';
import { BackofficeComponent } from './components/backoffice/backoffice.component';
import { ProductManagementComponent } from './components/backoffice/product-management/product-management.component';
import { CategoriesManagementComponent } from './components/backoffice/categories-management/categories-management.component';
import { CustomersManagementComponent } from './components/backoffice/customers-management/customers-management.component';

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
    ProductListItemComponent,
    SignupComponent,
    LoginComponent,
    AccountComponent,
    PagenotfoundComponent,
    OrderComponent,
    OrderListComponent,
    OrderItemComponent,
    CheckoutComponent,
    SuccessPopUpComponent,
    UserInfoComponent,
    BackofficeComponent,
    ProductManagementComponent,
    CategoriesManagementComponent,
    CustomersManagementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
