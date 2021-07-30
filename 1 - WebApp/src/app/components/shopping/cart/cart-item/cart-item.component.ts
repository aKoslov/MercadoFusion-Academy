import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/cart-item';
import { CartService } from 'src/app/services/cart.service';
import { MessengerService } from 'src/app/services/messenger.service';
import { CartComponent } from '../cart.component';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

   @Input() cartItem: CartItem = new CartItem(-1, '', '', -1, -1)

  constructor(private cart: CartComponent) { }

  ngOnInit(): void {
  }

  removeItem() {
    this.cart.removeFromCart(this.cartItem)
  }

}
