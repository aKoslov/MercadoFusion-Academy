import { Routes } from "@angular/router";
import { OrderComponent } from 'src/app/components/order-list/order/order.component';
import { PagenotfoundComponent } from 'src/app/components/pagenotfound/pagenotfound.component';
import { ShoppingComponent } from 'src/app/components/shopping/shopping.component';
import { LoginComponent } from 'src/app/components/users/login/login.component';
import { SignupComponent } from 'src/app/components/users/signup/signup.component';
import { BackofficeComponent } from "../components/backoffice/backoffice.component";
import { OrderListComponent } from "../components/order-list/order-list.component";
import { CheckoutComponent } from "../components/shopping/checkout/checkout.component";
import { AccountComponent } from "../components/users/account/account.component";

export const routes: Routes = [
    { path: '', component: ShoppingComponent },
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'orden', component: OrderComponent},
    { path: 'ordenes', component: OrderListComponent},
    { path: 'checkout', component: CheckoutComponent},
    { path: 'cuenta', component: AccountComponent},
    { path: 'gestion', component: BackofficeComponent },
    { path: '**', component: PagenotfoundComponent }
  ];