import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ProductCategory } from 'src/app/models/product-category';


@Injectable({
    providedIn: 'root'
  })


export class CategoryService {


    apiUrl = "https://localhost:5001/api/ProductsCategory/lista"

    
    constructor(private http: HttpClient) { }
  
    getProducts(): Observable<ProductCategory[]> {
      return this.http.get<ProductCategory[]>(this.apiUrl);
    }
}
