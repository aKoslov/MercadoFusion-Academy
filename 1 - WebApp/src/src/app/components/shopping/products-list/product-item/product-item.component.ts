import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessengerService } from "src/app/services/messenger.service";

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductListItemComponent implements OnInit {

  @Input() productItem: Product = new Product(0, 0, '', '', 0, new Date(), '')

  constructor(private messenger: MessengerService) { }

  ngOnInit(): void {
    
  }

  handleAddToCart () {
    this.messenger.sendMessage(this.productItem)
  }

}
