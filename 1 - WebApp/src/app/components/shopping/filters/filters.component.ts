import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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

  @Output() filtersEvent: EventEmitter<CatalogFilters> = new EventEmitter<CatalogFilters>()

  maxPrice: number = 0
  minPrice: number = -1
  filters = {
     Category: 0,
     PriceMin: -1,
     PriceMax: 0,
     Status: 0
   }
  sendFilters: string = ""
  categoriesList: ProductCategory[] = []
  categoryFilter: boolean = false

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {

    this.categoryService.getProducts().subscribe((categories: ProductCategory[]) => {
      this.categoriesList = categories
    });

  }

  

  loadFilters() {
    this.sendFilters = ""
    if (this.filters.Category != -1)
    {
    if (this.filters.Category === 0)
     this.categoryFilter = false
    this.sendFilters += "&Category=" + this.filters.Category
    this.categoryFilter = true
    }
    if (this.filters.PriceMax != 0) 
    this.sendFilters += "&priceMax=" + this.filters.PriceMax
    if (this.filters.PriceMin != -1)
    this.sendFilters += "&priceMin=" + this.filters.PriceMin
    if (this.filters.Status != -1) 
    this.sendFilters += "&status=" + this.filters.Status
    if (this.sendFilters != "")
    {
      this.filtersEvent.emit(new CatalogFilters(this.filters.Category, this.filters.PriceMax, this.filters.PriceMin, this.filters.Status))
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
