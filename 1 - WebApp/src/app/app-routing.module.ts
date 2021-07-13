import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { ShoppingComponent } from './components/shopping/shopping.component';
import { LoginComponent } from './components/users/login/login.component';
import { SignupComponent } from './components/users/signup/signup.component';

const routes: Routes = [
  { path: '', component: ShoppingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
