import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Product } from 'src/app/models/product';


const apiUrl = "https://localhost:5001/api/Product/catalogo?index=1&fetch=10"

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(apiUrl);
  }
  
}
 