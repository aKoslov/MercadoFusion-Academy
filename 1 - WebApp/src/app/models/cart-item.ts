export class CartItem {

    constructor (public productid: number,
                 public name: string, 
                 public description: string, 
                 public unitPrice: number,
                 public quantity: number)
                {
                    this.productid = productid
                    this.name = name
                    this.description = description
                    this.unitPrice = unitPrice
                    this.quantity = quantity
                }
}