import { Component, Input, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service';
import { CartComponent } from '../cart.component';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

   @Input() cartItem: any

  constructor(private messenger: MessengerService,
              private cart: CartComponent) { }

  ngOnInit(): void {
  }

  removeItem() {
    this.messenger.sendMessage(this.cartItem)
    this.cart.removeFromCart(this.cartItem)
  }

}
