import { Component, OnInit } from '@angular/core';
import { UserDto, UserLogin, UserSession  } from 'src/app/models/user';
import { UserTypes } from './config/enums';
import { MessengerService } from './services/messenger.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MercadoFusionWebAppCSS';
  user: UserDto = new UserDto(-1, 3)
  userType: UserTypes = UserTypes.Guest
  msgService: MessengerService = new MessengerService()
  
  ngOnInit(): void {
  }

  validateUserType() {
    return this.userType
  }

  stateUserType(userType: UserTypes) {
    this.userType = userType
  }

}
