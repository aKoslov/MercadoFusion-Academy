import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CartItem } from 'src/app/models/cart-item';
import { Order, OrderDetails, OrdersListResponse, OrderStatusDescription, OrderToSend } from 'src/app/models/order';
import { CartService } from 'src/app/services/cart.service';
import { MessengerService } from 'src/app/services/messenger.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})

export class OrderComponent implements OnInit {

  @Input() order: Order = new Order(new OrderDetails(0,'', new Date(),-1,-1), [])
  orderStatus: OrderStatusDescription = new OrderStatusDescription

  orderItems: CartItem[] = []

  constructor(private msgService: MessengerService,
              private orderService: OrderService,
              private cartService: CartService) { }

  ngOnInit(): void {
        this.msgService.getMessage().subscribe((order: Order) => 
              this.order = order
            )
        this.orderService.getUsersOrders(17).subscribe((orderResponse: OrdersListResponse) => 
              this.order = orderResponse.list[1])
    }  

    sendOrder() {
      this.cartService.deleteCart('')
    }
}