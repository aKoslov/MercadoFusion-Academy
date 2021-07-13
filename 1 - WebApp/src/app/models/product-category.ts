export class ProductCategory {

    constructor (public categoryID: number, 
                 public description: string =  ''
                 ) 

            {
        this.categoryID = categoryID
        this.description = description
    }

}
