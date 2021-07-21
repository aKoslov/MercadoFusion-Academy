import { Component, OnInit } from '@angular/core';
import { CatalogFilters } from 'src/app/models/catalog-filters';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.css']
})
export class ShoppingComponent implements OnInit {

  productList: Product[] = []

  constructor(private productService: ProductService) {

  }
  
  ngOnInit(): void {
    this.productService.getProductsPaginated(1, 12) .subscribe(list => this.productList = list)
  }

  filtersEvent(evt: CatalogFilters) {
    this.productService.getProductsFiltered(evt, 1, 12).subscribe(list => this.productList = list)
  
  }

  searchEvent(evt: string) {
    if (evt == "")
    this.productService.getProductsPaginated(1, 12) .subscribe(list => this.productList = list)
    else
    this.productService.getSearchResults(evt, 1, 12).subscribe(list => this.productList = list)
  }

}
