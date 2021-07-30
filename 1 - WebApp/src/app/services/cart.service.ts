import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';
import { orderUrl } from '../config/api';
import { CartItem } from '../models/cart-item';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  getCart(userToken: string) {
    let parsedCart: CartItem[] = JSON.parse(localStorage.getItem('user#7807ewsdf7:cart') || '{}');
    if (parsedCart.length != null)
    return parsedCart
    else 
    return []
  }

  addToCart(userToken: string, itemToAdd: CartItem) {
    let parsedCart = this.getCart('') 
    let productExists = false

      for(let index in parsedCart) {
        if (parsedCart[index].productid === itemToAdd.productid) {
        parsedCart[index].quantity++
        productExists = true
        break;
        }
      }

      if (!productExists) {
        parsedCart.push({
          productid: itemToAdd.productid,
          name: itemToAdd.name,
          description: itemToAdd.description,
          unitPrice: itemToAdd.unitPrice,
          quantity: 1
        })
      } 
    localStorage.setItem('user#7807ewsdf7:cart', JSON.stringify(parsedCart))
    return JSON.parse(localStorage.getItem('user#7807ewsdf7:cart') || '{}')
  }

  substractFromCart(itemToRemove: CartItem) {
    let parsedCart = this.getCart('')
    if (parsedCart == [])
        return []
    for(let item of parsedCart) {
      if (parsedCart[parsedCart.indexOf(item)].productid === itemToRemove.productid) {
        { 
          if (item.quantity > 1)
              parsedCart[parsedCart.indexOf(item)].quantity--
          else 
              parsedCart.splice(parsedCart.indexOf(item),1)
        }
      }
    }
    localStorage.setItem('user#7807ewsdf7:cart', JSON.stringify(parsedCart));
    return JSON.parse(localStorage.getItem('user#7807ewsdf7:cart') || '{}')
  }

  deleteCart(userToken: string) {
      localStorage.removeItem('user#7807ewsdf7:cart')
      return []
  }
}
