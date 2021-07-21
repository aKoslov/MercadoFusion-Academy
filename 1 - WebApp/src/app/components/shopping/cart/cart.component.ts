import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product';
import { CartItem } from 'src/app/models/cart-item';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems: CartItem[] = [] 

  cartTotal = 0

  constructor(private msgService: MessengerService) { }

  ngOnInit(): void {

      this.msgService.getMessage().subscribe((product: Product) => 
          this.addProductToCart(product)
        )
     }

  addProductToCart(product: Product) {

      let productExists = false

      for(let index in this.cartItems) {
        if (this.cartItems[index].productid === product.productID) {
        this.cartItems[index].quantity++
        productExists = true
        break;
        }
      }

      if (!productExists) {
        this.cartItems.push({
          productid: product.productID,
          name: product.name,
          description: product.description,
          price: product.price,
          quantity: 1
        })
      }
        this.cartTotal = 0
        this.cartItems.forEach( item => {
              this.cartTotal += item.price * item.quantity
        })
    }

    removeFromCart(item: CartItem) {
      this.cartItems.splice(this.cartItems.indexOf(item), 1)
    }
  }
  
