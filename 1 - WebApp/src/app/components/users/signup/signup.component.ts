
// import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { UserForSignup } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  model: any = {}
  signupForm: FormGroup = new FormGroup({})
  submitSuccess?: boolean

  constructor(private formBuilder: FormBuilder,
              private userService: UserService) {

   } 

  ngOnInit(): void {
    this.buildForm()
  }

  passwordsMatchValidator(form: FormGroup) {
    const password = form.get('password')
    const confirmPassword = form.get('confirmpassword')
    if (password?.value !== confirmPassword?.value)
    {
      confirmPassword?.setErrors({ passwordsMatch: true})
    } else {
      confirmPassword?.setErrors(null)
    }
  }

  buildForm() {
    this.signupForm = this.formBuilder.group({
      name: ['', Validators.required],
      lastname: ['', [Validators.required]],
      dni: ['', [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmpassword: ['', [Validators.required, Validators.minLength(6)]]
    }, {
      validators: this.passwordsMatchValidator
    })
  }

  signup() {
    let userDTO: UserForSignup = new UserForSignup(this.signupForm.get('name')?.value,
                                        this.signupForm.get('lastname')?.value,
                                        Number(this.signupForm.get('dni')?.value),
                                        this.signupForm.get('username')?.value
                                        )
    userDTO.password = this.signupForm.get('password')?.value
    this.userService.userSignUp(userDTO)
      
  }


}
