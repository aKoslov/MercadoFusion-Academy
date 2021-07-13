export class CatalogFilters {

    Category?: number
    PriceMin?: number
    PriceMax?: number
    Status?: number


    constructor (category: number,
                 pricemax: number,
                 pricemin: number,
                 status: number
            ) {
                this.Category = category,
                this.PriceMax = pricemax,
                this.PriceMin = pricemin,
                this.Status = status
    }

}
