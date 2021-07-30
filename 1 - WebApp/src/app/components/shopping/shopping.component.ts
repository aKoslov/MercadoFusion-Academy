import { Component, OnInit } from '@angular/core';
import { ListOrder } from 'src/app/config/enums';
import { CartItem } from 'src/app/models/cart-item';
import { CatalogFilters } from 'src/app/models/catalog-filters';
import { Order, OrdersListResponse, OrderToSend } from 'src/app/models/order';
import { Product, ProductListResponse } from 'src/app/models/product';  
import { CartService } from 'src/app/services/cart.service';
import { MessengerService } from 'src/app/services/messenger.service';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.css']
})
export class ShoppingComponent implements OnInit {

  productsList: Product[] = []
  productCount: number = 0
  productRequest?: ProductListResponse
  listFetch: number = 12
  listIndex: number = 1
  listMaxPrice: number = 0
  listMinPrice: number = 0
  listPages: number[] = []
  
  constructor(private productService: ProductService,
              private cartService: CartService,
              private orderService: OrderService,
              private msgService: MessengerService) {

  }
  
  ngOnInit(): void {
    this.productService.getProductsPaginated(this.listIndex, this.listFetch, ListOrder.None.valueOf()).subscribe(response => {
                                                                        this.productsList = response.list, 
                                                                        this.productCount = response.count,
                                                                        this.listMaxPrice = response.maxPrice,
                                                                        this.listMinPrice = response.minPrice,
                                                                        this.listPages = this.populatePaginated(Math.round(this.productCount / this.listFetch))
                                                                      }
                                                               )                    
  }

  filtersEvent(evt: CatalogFilters) {
    if (evt != undefined)
      this.productService.getProductsFiltered(evt, this.listIndex, this.listFetch).subscribe(response => {
                                                                                                        this.productsList = response.list, 
                                                                                                        this.productCount = response.count,
                                                                                                        this.listMaxPrice = response.maxPrice,
                                                                                                        this.listMinPrice = response.minPrice},
                                                                                          error => {
                                                                                                        this.productsList = []
                                                                                          }
                                                                  )
    else {
      this.productService.getProductsPaginated(this.listIndex, this.listFetch, ListOrder.None.valueOf()).subscribe(response => {
        this.productsList = response.list, 
        this.productCount = response.count,
        this.listMaxPrice = response.maxPrice,
        this.listMinPrice = response.minPrice,
        this.listPages = this.populatePaginated(Math.round(this.productCount / this.listFetch))
      }
)
    } 
      }

  searchEvent(evt: string) {
    if (evt == "") 
    {
    this.productService.getProductsPaginated(1, 12, ListOrder.None.valueOf()) .subscribe(response => {
                                                                                  this.productsList = response.list, 
                                                                                  this.productCount = response.count,
                                                                                  this.listMaxPrice = response.maxPrice,
                                                                                  this.listMinPrice = response.minPrice,
                                                                                  this.listPages = this.populatePaginated(Math.round(this.productCount / this.listFetch))})
    }
    else
    {
      this.productService.getSearchResults(evt, 1, 12).subscribe(response => {
                                                                            this.productsList = response.list, 
                                                                            this.productCount = response.count,
                                                                            this.listPages = this.populatePaginated(Math.round(this.productCount / 12))
                                                                          }
                                                                )
    }
  }

  indexEvent(evt: string) {
    this.productService.setIndex(evt).subscribe((response: ProductListResponse) =>{
                                                                                    this.productsList = response.list, 
                                                                                    this.productCount = response.count,
                                                                                    this.listMaxPrice = response.maxPrice,
                                                                                    this.listMinPrice = response.minPrice,
                                                                                    this.listPages = this.populatePaginated(Math.round(this.productCount / this.listFetch))})
  }

  populatePaginated(pages: number) {
    let resultArray: number[] = []
    for (let i = 1; i < pages + 1; i++) {
      resultArray.push(i)
    }
    return resultArray
  }

}
