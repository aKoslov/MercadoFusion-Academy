import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Product } from 'src/app/models/product';
 
@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject()

  constructor() { }

  sendMessage(input: any) {
    this.subject.next(input)

  }

  getMessage(): Observable<any> {  

    return this.subject

  }

}
