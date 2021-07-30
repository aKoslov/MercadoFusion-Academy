export class Product {
    public imageUrl: string = "https://cdn.pixabay.com/photo/2017/09/18/14/49/egg-sandwich-2761894_960_720.jpg";
    constructor (public id: number,
                 public categoryID: number,
                 public name: string, 
                 public description: string =  '', 
                 public price: number, 
                 public createdDate: Date,
                 public statusID: number) 
            {
        this.id = id
        this.categoryID = categoryID
        this.name = name
        this.description = description
        this.price = price
        this.createdDate = createdDate
        this.statusID = statusID
    }
}

export class ProductToSend {
    constructor(public CategoryID: number,
                public Name: string, 
                public Description: string =  '', 
                public Price: number, 
                public StatusID: number) {
                    this.CategoryID = CategoryID
                    this.Name = Name
                    this.Description  = Description
                    this.Price = Price
                    this.StatusID = StatusID
                }
            }
            
export class ProductListResponse {
    constructor (public list: Product[],
                 public count: number,
                 public maxPrice: number,
                 public minPrice: number) 
            {
        this.list = list
        this.count = count
        this.maxPrice = maxPrice
        this.minPrice = minPrice
    }
}