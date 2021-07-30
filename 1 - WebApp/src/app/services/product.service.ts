import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, TimeoutError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Product, ProductToSend } from 'src/app/models/product';
import { CatalogFilters } from 'src/app/models/catalog-filters';
import { productUrl } from 'src/app/config/api';
import { ProductListResponse } from 'src/app/models/product';
import { ListOrder } from '../config/enums';
import { numberToarray } from '../config/numberToarray-pipe';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  index: number = 1
  fetch: number = 12
  filters?: CatalogFilters
  isFiltered: boolean = false

  constructor(private http: HttpClient) { }

  getProductsPaginated(index: number, fetch: number, order: string): Observable<ProductListResponse> {
    this.index = index
    this.fetch = fetch
    return this.http.get<ProductListResponse>(
        productUrl + "catalogo", { params: { "index": index, "fetch": fetch, "order": order } }).pipe(retry(3));
  }
 
  getProductsFiltered(filters: CatalogFilters, index: number, fetch: number): Observable<ProductListResponse> {
    this.filters = filters
    let params: HttpParams = new HttpParams()
                                            .set("index", index) 
                                            .set("fetch", fetch)
                                            .set("category", filters.Category)
                                            .set("status", filters.Status)
                                            .set("pricemin", filters.PriceMin)
                                            .set("pricemax", filters.PriceMax)
    return this.http.get<ProductListResponse>(
        productUrl + "catalogo/filtros", { params: params } ).pipe(retry(3));
  }

  getSearchResults(search: string, index: number, fetch: number): Observable<ProductListResponse> {
    return this.http.get<ProductListResponse>(
        productUrl + "buscar/name", { params: { "index": index, "fetch": fetch, "name": search } }).pipe(retry(3));
  }

  setIndex(index: string): Observable<ProductListResponse> {
      if (index == "++")
      this.index++
    else
    {
      if (index == "--")
      this.index--
      else
      {
        this.index = Number.parseInt(index)
      }
    }
    if (!this.isFiltered) {
      return this.http.get<ProductListResponse>(
          productUrl + "catalogo", { params: { "index": this.index, "fetch": this.fetch, "order": ListOrder.None } }).pipe(retry(3));
    }
    if (this.filters != null) {
      let params: HttpParams = new HttpParams()
                                                .set("index", this.index) 
                                                .set("fetch", this.fetch)
                                                .set("category", this.filters.Category)
                                                .set("status", this.filters.Status)
                                                .set("pricemin", this.filters.PriceMin)
                                                .set("pricemax", this.filters.PriceMax)
      return this.http.get<ProductListResponse>(
      productUrl + "catalogo/filtros", { params: params } ).pipe(retry(3));
    }
    else {
      return this.http.get<ProductListResponse>(
        productUrl + "catalogo", { params: { "index": this.index, "fetch": this.fetch, "order": ListOrder.None } }).pipe(retry(3));
    }
  }

  getProductDetails(id: number): Observable<Product> {
    return this.http.get<Product>(
        productUrl + "buscar/id", {params: {"id": id } }).pipe(retry(3));
    
  }

  addProduct(newProduct: ProductToSend) {
    return this.http.post(
      productUrl + "staff/alta",  newProduct
    ).toPromise()
    
  }

  deleteProduct(productId: number) {
    return this.http.delete(
      productUrl + "staff/eliminar", { params: { "id": productId}}
    ).toPromise()
  }

}
 