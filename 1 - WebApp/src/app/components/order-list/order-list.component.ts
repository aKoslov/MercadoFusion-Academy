import { Component, Input, OnInit } from '@angular/core';
import { Order, OrdersListResponse } from 'src/app/models/order';
import { UserTypes } from 'src/app/config/enums';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  OrderList?: Order[] = [];
  orderCount: number = -1 
  @Input() userType?: UserTypes 
  @Input() userId: number = -1
  orderTotal: number = -1

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
      this.orderService.getUsersOrders(this.userId).subscribe((orders: OrdersListResponse) => {
        this.OrderList = orders.list
        this.orderCount = orders.count
    })
  }

  validateStaff() {
    if (this.userType == UserTypes.Staff) 
    return true
    else
    return false
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
