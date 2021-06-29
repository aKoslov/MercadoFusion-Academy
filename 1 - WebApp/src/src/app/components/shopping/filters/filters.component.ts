import { Component, OnInit } from '@angular/core';
import { ProductCategory } from 'src/app/models/product-category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {

  categoriesList: ProductCategory[] = []

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {

    this.categoryService.getProducts().subscribe((categories) => {
      this.categoriesList = categories
    });

  }
}
