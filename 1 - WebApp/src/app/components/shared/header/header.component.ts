import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private productSearch: ProductService) { }

  ngOnInit(): void {
  }

 
  
}
