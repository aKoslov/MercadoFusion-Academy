import { Product } from "./product"

export class ProductListRequest {
    constructor (public productList: Product[],
                 public productCount: number) 
            {
        this.productList = productList
        this.productCount = productCount
    }

}
