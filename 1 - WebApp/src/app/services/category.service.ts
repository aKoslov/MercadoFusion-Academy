import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { productcategoryUrl } from '../config/api';
import { ProductCategory } from 'src/app/models/product-category';


@Injectable({
    providedIn: 'root'
  })


export class CategoryService {

    
    constructor(private http: HttpClient) { }
  
    getProducts(): Observable<ProductCategory[]> {
      return this.http.get<ProductCategory[]>(productcategoryUrl + "lista");
    }
}
