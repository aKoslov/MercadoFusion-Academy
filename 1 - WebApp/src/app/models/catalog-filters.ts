export class CatalogFilters {

    public Category: number 
    public PriceMin: number
    public PriceMax: number 
    public Status: number

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
