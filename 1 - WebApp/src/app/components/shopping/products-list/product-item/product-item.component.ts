import { Component, OnInit, Input } from '@angular/core';
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

  @Input() productItem: Product = new Product(0, 0, '', '', 0, new Date(), '')

  constructor(private messenger: MessengerService,
              private wishlistService: WishListService          
    ) {}


      //Solución posiblemente más eficiente
  ngOnInit() {
    this.addedToWishList = this.wishlistService.isAdded(this.productItem.productID)
  }
      //Solución más acorde
  // ngOnChange() {

  // }

  handleAddToCart () {
    this.messenger.sendMessage(this.productItem)
  }

  handleAddToWishList () {
    this.wishlistService.addToWishList(this.productItem.productID)
    this.addedToWishList = true
  }

  handleRemoveFromWishList () {
    this.wishlistService.removeFromWishList(this.productItem.productID)
    this.addedToWishList = false
  }
}
