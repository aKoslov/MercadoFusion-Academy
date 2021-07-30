import { Component, OnInit } from '@angular/core';
import { UserTypes } from 'src/app/config/enums';
import { OrdersListResponse } from 'src/app/models/order';
import { MessengerService } from 'src/app/services/messenger.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  userId: number = 17
  ordersDisplay: boolean = true
  accountInfoDisplay: boolean = true
  userType: UserTypes = UserTypes.Customer

  constructor(private orderService: OrderService,
              private msgService: MessengerService) { }

  ngOnInit(): void {
    this.orderService.getUsersOrders(this.userId).subscribe((orders: OrdersListResponse) => this.msgService.sendMessage(orders))
  }

  validateStaff() {
    if (this.userType == UserTypes.Staff) 
    return true
    else 
    return false
  }

  displayOrders() {
    this.ordersDisplay = true
    this.accountInfoDisplay = false
  }

  displayUserInfo() {
    this.ordersDisplay = false
    this.accountInfoDisplay = true
  }
}
