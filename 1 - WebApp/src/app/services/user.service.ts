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
  // https://localhost:5001/api/User/signup?Username=asd&Name=asd&LastName=asd&DNI=21312123&Password=asdasd

  constructor(private http: HttpClient) { }
  
    userSignUp(user: UserInfo){
      // return this.http.post<UserInfo>((userUrl+ "/signup?Username=" + user.username + "&Name=" + user.firstname + "&LastName=" + user.lastname + "&DNI=" + user.dni + "&Password=" + password), { body: "User Signup"})
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Access-Control-Allow-Origin' });
    let options = { headers: headers }
    
      return this.http.post(userUrl + "/signup", JSON.stringify(user), options).subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      )
    }
    // getProductsPaginated(index: number, fetch: number): Observable<UserInfo[]> {
    //   return this.http.get<Product[]>(this.apiUrl + "?index=" + index + "&fetch=" + fetch).pipe(retry(3));
    // }
   
    // getProductsFiltered(filters: string): Observable<Product[]> {
    //   return this.http.get<Product[]>(
    //     this.apiUrl + "/filtros" + "?index=" + this.index + "&fetch=" + this.fetch + filters).pipe(retry(3))
        
    // }
    
}
