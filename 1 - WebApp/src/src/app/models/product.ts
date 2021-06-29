export class Product {
    // public id?: number;
    // public categoryid?: number;
    // public name?: string;
    // public description?: string;
    // public price: number;
    // public statusid?: number;
    // public addedDate?: string;
     //public imageUrl: string = "https://cdn.pixabay.com/photo/2017/09/18/14/49/egg-sandwich-2761894_960_720.jpg";

    constructor (public productID: number,
                 public categoryid: number,
                 public name: string, 
                 public description: string =  '', 
                 public price: number, 
                 public addedDate: Date,
                 public imageUrl:string) 
            {
        this.productID = productID
        this.categoryid = categoryid
        this.name = name
        this.description = description
        this.price = price
        this.addedDate = addedDate
        this.imageUrl = "https://cdn.pixabay.com/photo/2017/09/18/14/49/egg-sandwich-2761894_960_720.jpg"
    }

}
