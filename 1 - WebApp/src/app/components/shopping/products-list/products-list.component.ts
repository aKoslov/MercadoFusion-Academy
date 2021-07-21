import { stringify } from '@angular/compiler/src/util';
import { Component, Input, OnInit } from '@angular/core';

import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})


export class ProductsListComponent implements OnInit{

  @Input() productsList: Product[] = []

  searchInput: string = ""

  constructor() {
   }
   
  ngOnInit(): void {
  }
 

}

