import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, TimeoutError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Product } from 'src/app/models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl = "https://localhost:5001/api/Product/catalogo"
  index: number = 1
  fetch: number = 12

  constructor(private http: HttpClient) { }

  getProductsPaginated(index: number, fetch: number): Observable<Product[]> {
    this.index = index; 
    this.fetch = fetch
    return this.http.get<Product[]>(this.apiUrl + "?index=" + index + "&fetch=" + fetch).pipe(retry(3));
  }
 
  getProductsFiltered(filters: string): Observable<Product[]> {
    return this.http.get<Product[]>(
      this.apiUrl + "/filtros" + "?index=" + this.index + "&fetch=" + this.fetch + filters).pipe(retry(3))
      
  }
  
}
 