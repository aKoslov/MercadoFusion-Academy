import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';
import { orderUrl } from '../config/api';
import { Order, OrdersListResponse, OrderToSend } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }
  
  sendOrder(newOrder: OrderToSend) {
    return this.http.post<OrderToSend>(
        orderUrl + "send", newOrder 
                ).subscribe((response) => console.log(response),
                            (error) => console.log(error));
  }

  getUsersOrders(userId: number): Observable<OrdersListResponse> {
    return this.http.get<OrdersListResponse> (
      orderUrl + "list", { params: { "userid": userId } }
                );
  }
  
  getOrders() {
    return this.http.get<OrdersListResponse> (
      orderUrl + "list"
                );
  }

  updateOrderStatus(updatedOrder: Order) {
    return this.http.put<Order> (
      orderUrl + "update", { body: { updatedOrder } }
                );
  }
}
