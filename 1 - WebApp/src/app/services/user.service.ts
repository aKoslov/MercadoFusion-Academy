import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { userUrl } from '../config/api';
import { UserDto, UserForSignup, UserLogin, UserSession } from '../models/user';
import { MessengerService } from './messenger.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  

  constructor(private http: HttpClient,
              private msgService: MessengerService) { }
  
    
  signOut() {
    localStorage.removeItem('userId')
    localStorage.removeItem('userType')
  }

  isLogged() {
    let userType = localStorage.getItem('userType')
    if (userType == null) 
        return false 
    else 
      {
        if (Number.parseInt(userType) == 3)
        return false
        else
        return true
      }  
  }

  validateStaff() {
    let userType = localStorage.getItem('userType')
    if (userType != null) {
      if (Number.parseInt(userType) == 2)
      return true
      else
      return false
    }
    return false
  }

  getUserId() {
    let userId = localStorage.getItem('userId')
    if(userId == null)
      return -1
    else
      {
        return Number.parseInt(userId)
      }
  }

    userSignUp(newSignup: UserForSignup){
      return this.http.post(userUrl + "signup", newSignup).subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      )
    }

    userLogin(newLogin: UserLogin) {
      // const httpOptions = {
      //   headers: new HttpHeaders({
      //     'Content-Type':  'application/json'
      //   }),
      //   observe: 'observe'
      // }
      const httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
    
//       return this.http.post('http://localhost:3000/api/Users/login', data, httpOptions)
//    .do( function(resp) {
//         self.setSession(resp);
//  });
        return this.http.post<UserSession>(
          userUrl + "login", newLogin, httpOptions ).subscribe((response: UserSession) => {
                  localStorage.setItem('userId', JSON.stringify(response.userId)),
                  localStorage.setItem('userType', JSON.stringify(response.userType))
          })
        //   .subscribe({
        //     next: data => {
        //         this.msgService.sendMessage(new UserDto(data.id, data.userType))
        //         return true
        //     },
        //     error: error => {
        //         return false
        //     }
        // })
    }

    getUsersList(): Observable<UserDto[]> {
      return this.http.get<UserDto[]>(
        userUrl + "clientes/token"
      )
    }
}
