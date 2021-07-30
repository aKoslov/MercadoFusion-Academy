import { Component, OnInit, Input } from '@angular/core';
import { CartItem } from 'src/app/models/cart-item';
import { Product } from 'src/app/models/product';
import { MessengerService } from "src/app/services/messenger.service";
import { WishListService } from "src/app/services/wishlist.service";


@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductListItemComponent implements OnInit {

  addedToWishList: boolean = false;
  quantity: number = 1

  @Input() productItem: Product = new Product(0, 0, '', '', 0, new Date(), -1)

  constructor(private messenger: MessengerService,
              private wishlistService: WishListService          
    ) {}

  ngOnInit() {
    this.addedToWishList = this.wishlistService.isAdded(this.productItem.id)
  }
  
  handleAddToCart () {
    let parsedCartItem: CartItem = new CartItem(this.productItem.id, this.productItem.name, this.productItem.description, this.productItem.price, this.quantity)
    this.messenger.sendMessage(parsedCartItem)
  }

  handleAddToWishList () {
    this.wishlistService.addToWishList(this.productItem.id)
    this.addedToWishList = true
  }

  handleRemoveFromWishList () {
    this.wishlistService.removeFromWishList(this.productItem.id)
    this.addedToWishList = false
  }
}
