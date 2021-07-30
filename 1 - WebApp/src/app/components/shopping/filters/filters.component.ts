import { ElementSchemaRegistry } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CatalogFilters } from 'src/app/models/catalog-filters';
import { ProductCategory } from 'src/app/models/product-category';
import { CategoryService } from 'src/app/services/category.service';
import { WishListService } from 'src/app/services/wishlist.service';
import { ProductsListComponent } from '../products-list/products-list.component';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {

  @Output() filtersEvent: EventEmitter<CatalogFilters> = new EventEmitter<CatalogFilters>()
  @Input() listMaxPrice: number = 120000
  @Input() listMinPrice: number = 0

  categoriesList: ProductCategory[] = []
  catalogFilters: CatalogFilters = new CatalogFilters()
  sendFilters: string = ""
  categoryFilter: boolean = false
  appliedFilters: boolean = false

  constructor(private categoryService: CategoryService) { 
  }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((categories: ProductCategory[]) => {
      this.categoriesList = categories
    });
  }

  setRangeValue(which: string) {
    if (which == "min")
      this.catalogFilters.PriceMin = Number((<HTMLInputElement>document.getElementById('MinRange')).value);
    if (which == "max")
      this.catalogFilters.PriceMax = Number((<HTMLInputElement>document.getElementById('MaxRange')).value);
    (<HTMLInputElement>document.getElementById('MaxRange')).min = String(this.catalogFilters.PriceMin);
    (<HTMLInputElement>document.getElementById('MinRange')).max = String(this.catalogFilters.PriceMax);
  }

  loadFilters() {
      if (this.catalogFilters.PriceMax == -1)
        this.catalogFilters.PriceMax = this.listMaxPrice
      this.filtersEvent.emit(this.catalogFilters)
      if (this.catalogFilters.Category > 0) 
        this.categoryFilter = true
      else
        this.categoryFilter = false
      this.appliedFilters = true
  }

  resetFilterds() {
    this.catalogFilters = new CatalogFilters()
    
  }

  filterCategory(category: number) {
    this.catalogFilters.Category = category
  }

  filterStock() {
    if (this.catalogFilters.Status == -1)
    this.catalogFilters.Status = 1
    else
    this.catalogFilters.Status = -1
  }


  hasWishlist() {
    if (localStorage.getItem('wishlist') != null)
    return true
    else
    return false
  }
}
