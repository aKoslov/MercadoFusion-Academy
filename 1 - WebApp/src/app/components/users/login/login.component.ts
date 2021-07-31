import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
              private loginService: UserService,
              private formBuilder: FormBuilder) { }

  model: any = {}
  loginForm: FormGroup = new FormGroup({})
  submitSuccess?: boolean

  ngOnInit(): void {
    this.buildForm()
  }

  buildForm() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required]],
      remember: []
    })
  }


  login() {
    let newLogin: UserLogin = new UserLogin(this.loginForm.get('username')?.value,
                                            this.loginForm.get('password')?.value
    )
    this.loginService.userLogin(newLogin)
    
  }

}
