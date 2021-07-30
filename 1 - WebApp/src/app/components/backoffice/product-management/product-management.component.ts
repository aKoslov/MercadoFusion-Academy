import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ListOrder } from 'src/app/config/enums';
import { Product, ProductListResponse, ProductToSend } from 'src/app/models/product';
import { ProductCategory } from 'src/app/models/product-category';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent implements OnInit {

  productList: Product[] = []
  productForm: any
  categories: ProductCategory[] = []

  constructor(private productService: ProductService,
              private categoryService: CategoryService,
              private formBuilder: FormBuilder) {
          this.productForm = this.formBuilder.group( {
                name: ['', Validators.required],
                description: ['', Validators.required],
                price: ['', [Validators.required,  Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
                categoryID: ['', Validators.required],
                statusId: ''
          })
        }

  ngOnInit(): void {
    this.getProducts(1,30)
    this.categoryService.getCategories().subscribe((list: ProductCategory[]) => {
      this.categories = list
    })
    }

    getProducts(index: number, fetch: number) {
      this.productService.getProductsPaginated(index,fetch, ListOrder.TimeDesc).subscribe((productResponse: ProductListResponse) => {
        this.productList = productResponse.list
      })    
    }

    addProduct() {
      let productDTO: ProductToSend = new ProductToSend(
                                        Number(this.productForm.get('categoryID')?.value),
                                        this.productForm.get('name')?.value,
                                        this.productForm.get('description')?.value,
                                        Number(this.productForm.get('price')?.value),
                                        Number(this.productForm.get('statusId')?.value)
                                        )
        this.productService.addProduct(productDTO).then(() => {
          this.getProducts(1,30)
        })
        
    }

    deleteProduct(productId: number) {
      this.productService.deleteProduct(productId).then(() => this.getProducts(1,30), 
                                                        () => this.getProducts(1,30))
    }

}
