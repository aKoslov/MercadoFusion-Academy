import { CartItem } from "./cart-item"

export class OrderStatusDescription {
    public description: string[] = ['Paga', 'Pendiente', 'Cancelada']
}

export class OrderDetails {
    constructor (public id: number,
                 public billingNumber: string,
                 public createdDate: Date,
                 public userId: number,
                 public statusId: number){
                    this.id = id
                    this.billingNumber = billingNumber
                    this.createdDate = createdDate
                    this.userId = userId
                    this.statusId = statusId
                }
    }

export class Order {
    constructor (public details: OrderDetails,
                 public items: CartItem[]) {
                     this.details = details
                     this.items = items
                 }
    }

export class OrdersListResponse {
    constructor (public list: Order[],
                 public count: number) {
                     this.list = list
                     this.count = count
                 }
}

export class OrderToSend {
    constructor (public createdDate: Date,
                 public userId: number,
                 public statusId: number,
                 public cart: CartItem[],
                 ) {
                     this.cart = cart
                     this.createdDate = createdDate
                     this.userId = userId 
                     this.statusId = statusId
                     this.cart = cart
                 }
}

