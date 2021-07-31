import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { WishListService } from 'src/app/services/wishlist.service';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private userService: UserService,
              private wishlistService: WishListService) { }

  ngOnInit(): void {
    this.userService.validateStaff()
  }
  
  isLogged() {
    return this.userService.isLogged()
  }

  validateStaff() {
    return this.userService.validateStaff()
  }

  signOut()
   {
     localStorage.removeItem('wishlist')
     return this.userService.signOut()

   }

}
