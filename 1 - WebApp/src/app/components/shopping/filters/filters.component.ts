import { Component, OnInit } from '@angular/core';
import { productUrl } from 'src/app/config/api';
import { CatalogFilters } from 'src/app/models/catalog-filters';
import { Product } from 'src/app/models/product';
import { ProductCategory } from 'src/app/models/product-category';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';
import { ProductsListComponent } from '../products-list/products-list.component';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {

  maxPrice: number = 0
  minPrice: number = -1

  filters = {
    Category: 0,
    PriceMin: -1,
    PriceMax: 0,
    Status: -1
  }
  sendFilters: string = ""
  categoriesList: ProductCategory[] = []
  //https://localhost:5001/api/Product/catalogo/filtros?Category=1&Price=10&Status=1&index=1&fetch=10

  constructor(private categoryService: CategoryService,
              private productService: ProductService,
              private prod: ProductsListComponent) { }

  ngOnInit(): void {

    this.categoryService.getProducts().subscribe((categories: ProductCategory[]) => {
      this.categoriesList = categories
    });

  }

  loadFilters() {
    this.sendFilters = ""
    if (this.filters.Category != 0)
    this.sendFilters += "&Category=" + this.filters.Category    
    if (this.filters.PriceMax != 0) 
    this.sendFilters += "&priceMax=" + this.filters.PriceMax
    if (this.filters.PriceMin != -1)
    this.sendFilters += "&priceMin=" + this.filters.PriceMin
    if (this.filters.Status != -1) 
    this.sendFilters += "&status=" + this.filters.Status
    if (this.sendFilters != "")
    {
      this.productService.getProductsFiltered(this.sendFilters).subscribe((products: Product[]) => {
        this.prod.loadProducts(products)
      })

    }

  }

  filterCategory(category: number) {
    this.filters.Category = category
  }

  filterStock() {
    if (this.filters.Status == 0)
    this.filters.Status = 1
    else
    this.filters.Status = 0
  }

  filterPrice(price: number, MinOrMax: string) {
    if (MinOrMax == "min") 
    this.filters.PriceMin = price
    else
    this.filters.PriceMax = price
  }

}
