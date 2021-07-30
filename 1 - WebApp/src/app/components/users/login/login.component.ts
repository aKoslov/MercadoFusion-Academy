import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserLogin } from 'src/app/models/user';
import { MessengerService } from 'src/app/services/messenger.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private msgService: MessengerService,
              private loginService: UserService) { }

  model: any
  username?: string
  password?: string
  remember: boolean = false

  ngOnInit(): void {
  }

  login() {
    this.loginService.userLogin(new UserLogin(this.model[0] || '', this.model[1] || ''))
  }

}
