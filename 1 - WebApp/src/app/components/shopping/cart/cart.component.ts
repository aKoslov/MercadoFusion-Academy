import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product';
import { CartItem } from 'src/app/models/cart-item';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  @Output() orderEvent: EventEmitter<CartItem[]> = new EventEmitter<CartItem[]>()

  cartItems: CartItem[] = [] 
  cartTotal = 0

  constructor(private msgService: MessengerService,
              private cartService: CartService) { }

  ngOnInit(): void {
      this.msgService.getMessage().subscribe((cartItem: CartItem) => 
          this.addToCart(cartItem) 
        )
      this.cartItems = this.cartService.getCart('')
      this.calculateTotal()
     }

  addToCart(itemToAdd: CartItem) {
        this.cartItems = this.cartService.addToCart('', itemToAdd)
        this.calculateTotal()
    }

    deleteCart() {
      this.cartItems = this.cartService.deleteCart('')
    }

    removeFromCart(itemToRemove: CartItem) {
      this.cartItems = this.cartService.substractFromCart(itemToRemove)
      this.calculateTotal()
    }

    calculateTotal() {
      this.cartTotal = 0
      this.cartItems.forEach( item => {
            this.cartTotal += item.unitPrice * item.quantity
      })
    }

  }
  
