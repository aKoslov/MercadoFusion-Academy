import { Injectable } from '@angular/core';
import { ProductsListComponent } from '../components/shopping/products-list/products-list.component';

@Injectable({
  providedIn: 'root'
})
export class WishListService {

  constructor() {
   }

  getWishList() {
    return localStorage.getItem("wishlist")
  }

  isAdded(productID: number) : boolean {
    var wishlist = this.getWishList()
    if (wishlist != null)
    {
      for(let product of wishlist.split(",")) {
        if (product.toString() == productID.toString()) {
          return true
        }
      }
    return false
    }
    return false
  }

  addToWishList(productID: number) {
    var wishlist = this.getWishList()
    if (wishlist === null)
    {
      localStorage.setItem("wishlist", JSON.stringify(productID))
    } else 
    {
      localStorage.setItem("wishlist", wishlist + "," + productID.toString())
    }
  }

  removeFromWishList(productID: number) {
    var wishlist = this.getWishList()
    if (wishlist != null) {
      var wishlistArray: Array<string>
      wishlistArray = wishlist.toString().split(',')
      if (wishlistArray.length > 1)
      {
        wishlistArray.splice(wishlistArray.indexOf(productID.toString()), 1)
        localStorage.setItem("wishlist", (wishlistArray.toString()))
      }
      else {
        localStorage.removeItem("wishlist")
      }
    }
  }

}


