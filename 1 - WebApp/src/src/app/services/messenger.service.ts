import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from 'src/app/models/product';
 
@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject()

  constructor() { }

  sendMessage(product: Product) {
    this.subject.next(product)

  }

  getMessage() {  

    return this.subject.asObservable()

  }

}
