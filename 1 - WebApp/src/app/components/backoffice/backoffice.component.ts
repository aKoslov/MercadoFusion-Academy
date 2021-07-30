import { Component, OnInit } from '@angular/core';
import { UserTypes } from 'src/app/config/enums';
import { UserDto } from 'src/app/models/user';

@Component({
  selector: 'app-backoffice',
  templateUrl: './backoffice.component.html',
  styleUrls: ['./backoffice.component.css']
})
export class BackofficeComponent implements OnInit {

  // productsDisplay: boolean = true
  // categoriesDisplay: boolean = false
  // usersDisplay: boolean = false
  // ordersDisplay: boolean = false
  // accountInfoDisplay : boolean = false
  userInfo: UserDto = new UserDto
  userType: UserTypes = UserTypes.Staff
  display: string = "SProducts"

  constructor() { }

  ngOnInit(): void {
    console.log(this.display[5])
  }

  setDisplay(tab: number) {
    switch (tab) {
      case 1:
        this.display = "SProducts"
        break;
      case 2:
        this.display = "SCategories"
        break;
      case 3:
        this.display = "SOrders"
        break;
      case 4:
        this.display = "SUsersList"
        break;
      case 5:
        this.display = "UserInfo"
        break;
    }
  }
  

}
