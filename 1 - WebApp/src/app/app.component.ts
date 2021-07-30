import { Component, OnInit } from '@angular/core';
import { UserDto  } from 'src/app/models/user';
import { UserTypes } from './config/enums';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MercadoFusionWebAppCSS';
  user: UserDto = new UserDto()
  userType: UserTypes = UserTypes.Guest
  
  ngOnInit(): void {
  }

  validateUserType() {
    return this.userType
  }

  stateUserType(userType: UserTypes) {
    this.userType = userType
  }

}
