import { Component, Input, OnInit } from '@angular/core';
import { Order, OrdersListResponse } from 'src/app/models/order';
import { UserTypes } from 'src/app/config/enums';
import { OrderService } from 'src/app/services/order.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  OrderList?: Order[] = [];
  orderCount: number = -1 
  orderTotal: number = -1

  constructor(private orderService: OrderService,
              private userService: UserService) { }

  ngOnInit(): void {
    if (!this.validateStaff()) 
      {
              this.orderService.getUsersOrders(this.userService.getUserId()).subscribe((orders: OrdersListResponse) => {
              this.OrderList = orders.list
              this.orderCount = orders.count
          })
      }
      else
      {
        this.orderService.getUsersOrders(-1).subscribe((orders: OrdersListResponse) => {
          this.OrderList = orders.list
          this.orderCount = orders.count
      })
      }
  }

  validateStaff() {
    return this.userService.validateStaff()
  }

  validateStatus(statusId: number) {
    switch (statusId) {
      case 1:
        return "Paga"
      case 2:
        return "Pago Pendiente"
      case 3:
        return "Cancelada"
      default:
        return "¯\_ (ツ)_/¯"
    }
  }

  calculateTotal(order: Order) {
    this.orderTotal = 0
    order.items.forEach( item => {
          this.orderTotal += item.unitPrice * item.quantity
    })
    return this.orderTotal
  }

}
