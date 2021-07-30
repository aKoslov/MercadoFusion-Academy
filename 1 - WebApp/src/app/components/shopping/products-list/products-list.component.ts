import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ListOrder } from 'src/app/config/enums';
import { Product } from 'src/app/models/product';
import { numberToarray } from 'src/app/config/numberToarray-pipe';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})


export class ProductsListComponent implements OnInit{

  @Output() searchEvent: EventEmitter<string> = new EventEmitter<string>()
  @Output() orderEvent: EventEmitter<string> = new EventEmitter<string>()
  @Output() indexEvent: EventEmitter<string> = new EventEmitter<string>()
  @Input() productsList: Product[] = []
  @Input() productCount: number = 0
  @Input() listFetch: number = 12
  @Input() listPages: number[] = []
  listIndex: number = 1
  listOrder: ListOrder = ListOrder.None

  constructor() {
   }
   
  ngOnInit(): void {
  }
 
  setOrder(switchcase: number) {
    switch (switchcase) {
      case 1:
        this.listOrder = ListOrder.AlphaAsc
        break;
      case 2:
        this.listOrder = ListOrder.AlphaDesc
        break;
      case 3:
        this.listOrder = ListOrder.PriceyFirst
        break;
      case 4:
        this.listOrder = ListOrder.CheaperFirst
        break;
      case 5:
        this.listOrder = ListOrder.None
        break;
    }
  }

  order() {
    this.orderEvent.emit(this.listOrder.toString())
  }

  index(evt: string) {
    switch (evt) {
      case "--":
        if (this.listIndex != 1) 
        {
          this.indexEvent.emit(evt)
          this.listIndex--
        }
        break;
        case "++":
          if (this.listIndex != this.listPages.length) 
        {
          this.indexEvent.emit(evt)
          this.listIndex++
        }
        break;
      default:
        this.indexEvent.emit(evt)
        break;
    }

    
  }

  search() {
    this.searchEvent.emit((<HTMLInputElement>document.getElementById('searchbar')).value)
  }

  handleEnter(evt: any): void {
    var key=evt.keycode  || evt.which;
    if (key==13){
        this.search()
    }
  }

}

