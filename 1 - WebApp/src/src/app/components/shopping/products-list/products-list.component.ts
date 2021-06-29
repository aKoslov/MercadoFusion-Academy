import { Component, OnInit } from '@angular/core';

import { Product } from 'src/app/models/product';

import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  productsList: Product[] = []

  constructor(private productService: ProductService) {



   }
   
  ngOnInit(): void {

      this.productService.getProducts().subscribe((products) => {
        this.productsList = products
      });

  }

}
