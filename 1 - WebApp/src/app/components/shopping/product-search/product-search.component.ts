import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-search',
  templateUrl: './product-search.component.html',
  styleUrls: ['./product-search.component.css']
})
export class ProductSearchComponent implements OnInit {

  @Output() searchEvent: EventEmitter<string> = new EventEmitter<string>()

  constructor(private productSearch: ProductService) { }

  ngOnInit(): void {
  }

  search(index: number, fetch: number) {
    console.log((<HTMLInputElement>document.getElementById('searchbar')).value)
    this.searchEvent.emit((<HTMLInputElement>document.getElementById('searchbar')).value)
    console.log("searccc")
    // this.productSearch.getSearchResults(, index, fetch)
  }

  handleEnter(evt: any): void {
    var key=evt.keycode  || evt.which;
    if (key==13){
        this.search(1, 12)
    }
  }
  
}
