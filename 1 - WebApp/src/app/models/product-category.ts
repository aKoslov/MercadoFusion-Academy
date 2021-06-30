export class ProductCategory {

    constructor (public name: string, 
                 public description: string =  ''
                 ) 

            {
        this.name = name
        this.description = description
    }

}
