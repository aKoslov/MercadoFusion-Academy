import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { userUrl } from '../config/api';
import { UserDto, UserForSignup, UserLogin } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  

  constructor(private http: HttpClient) { }
  
    userSignUp(newSignup: UserForSignup){
      return this.http.post(userUrl + "signup", newSignup).subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      )
    }

    userLogin(newLogin: UserLogin) {
        
    }

    getUsersList(): Observable<UserDto[]> {
      return this.http.get<UserDto[]>(
        userUrl + "clientes/token"
      )
    }
}
