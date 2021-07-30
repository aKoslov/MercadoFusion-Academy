import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/cart-item';
import { OrdersListResponse, OrderToSend } from 'src/app/models/order';
import { CartService } from 'src/app/services/cart.service';
import { MessengerService } from 'src/app/services/messenger.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  @Input() checkoutOrder: OrderToSend = new OrderToSend(new Date(), 17, 2, [])

  cartTotal: number = -1

  constructor(private cartService: CartService,
              private orderService: OrderService) { }

  ngOnInit(): void {
      this.checkoutOrder.cart = this.cartService.getCart('')
      this.calculateTotal()
  }
  
    sendOrder() {
        this.checkoutOrder.createdDate = new Date()
        this.orderService.sendOrder(this.checkoutOrder)
        this.cartService.deleteCart('')
    }

    calculateTotal() {
      this.cartTotal = 0
      this.checkoutOrder.cart.forEach(item => {
        this.cartTotal += item.quantity * item.unitPrice
      })
    }

    quantityEvent(evt: CartItem) {
      this.calculateTotal()
    }

}
