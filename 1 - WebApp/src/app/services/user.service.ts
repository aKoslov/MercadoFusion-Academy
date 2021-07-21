import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TagContentType } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { userUrl } from '../config/api';
import { UserInfo } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  

  constructor(private http: HttpClient) { }
  
    userSignUp(user: UserInfo){
      
      return this.http.post(userUrl + "/signup", user).subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      )
    }
}
