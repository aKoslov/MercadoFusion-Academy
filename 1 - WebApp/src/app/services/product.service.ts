import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, TimeoutError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Product } from 'src/app/models/product';
import { CatalogFilters } from '../models/catalog-filters';
import { productUrl } from '../config/api';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  index: number = 1
  fetch: number = 12

  constructor(private http: HttpClient) { }

  getProductsPaginated(index: number, fetch: number): Observable<Product[]> {
    this.index = index; 
    this.fetch = fetch
    return this.http.get<Product[]>(productUrl + "catalogo", { params: { "index": index, "fetch": fetch } }).pipe(retry(3));
  }
 
  getProductsFiltered(filters: CatalogFilters, index: number, fetch: number): Observable<Product[]> {
    let params: HttpParams = new HttpParams()
                                            .set("index", index) 
                                            .set("fetch", fetch)
    if (filters.Category != 0)
      params = params.append("Category", filters.Category)
    else
      params = params.delete("category")
    return this.http.get<Product[]>(
      productUrl + "catalogo/filtros", { params: params } ).pipe(retry(3));
  }

  getSearchResults(search: string, index: number, fetch: number): Observable<Product[]> {
    return this.http.get<Product[]>(
        productUrl + "buscar", { params: { "index": index, "fetch": fetch, "name": search } }).pipe(retry(3));
  }

  getProductDetails(id: number): Observable<Product[]> {
    return this.http.get<Product[]>(
      productUrl).pipe(retry(3));
    
  }

}
 