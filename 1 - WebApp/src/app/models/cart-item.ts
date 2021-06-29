export class CartItem {

    constructor (public productid: number,
                 public name: string, 
                 public description: string, 
                 public price: number,
                 public quantity: number)
                {
                    this.productid = productid
                    this.name = name
                    this.description = description
                    this.price = price
                    this.quantity = quantity
                }
}