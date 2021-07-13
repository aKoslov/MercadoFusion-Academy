import { ChangeDetectorRef, Component, Injectable, OnInit } from '@angular/core';
import { RouteConfigLoadEnd } from '@angular/router';

import { Product } from 'src/app/models/product';

import { ProductService } from 'src/app/services/product.service';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit{

  productsList: Product[] = []

  constructor(private productService: ProductService,
              private cd: ChangeDetectorRef) {
      if (this.productsList.length == 0)
            this.productService.getProductsPaginated(1, 12).subscribe((products: Product[]) => {
              this.productsList = products})
          this.cd.markForCheck()
   }
   
  ngOnInit(): void {
  }


  public loadProducts(products: Product[]): void {
    // this.productsList = []
    this.productsList = products
    this.cd.detectChanges()
    this.ngOnInit()
    
    // location.reload()
    
  }

  // public handleWhishList(Product): void {
  //   return
  // }
  

}
