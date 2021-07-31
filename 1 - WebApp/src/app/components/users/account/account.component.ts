import { Component, OnInit } from '@angular/core';
import { UserTypes } from 'src/app/config/enums';
import { OrdersListResponse } from 'src/app/models/order';
import { MessengerService } from 'src/app/services/messenger.service';
import { OrderService } from 'src/app/services/order.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  userId: number = -1
  ordersDisplay: boolean = true
  accountInfoDisplay: boolean = false

  constructor(private orderService: OrderService,
              private msgService: MessengerService,
              private userService: UserService) { }

  ngOnInit(): void {

    if (this.validateStaff())
      this.userId = -1  
    else
      this.userId = this.userService.getUserId()
    this.orderService.getUsersOrders(-1).subscribe((orders: OrdersListResponse) => this.msgService.sendMessage(orders))
  }

  validateStaff() {
    return this.userService.validateStaff()
  }

  displayOrders() {
    this.accountInfoDisplay = false
    this.ordersDisplay = true
  }

  displayUserInfo() {
    this.ordersDisplay = false
    this.accountInfoDisplay = true
  }
}
