import { environment } from "src/environments/environment";

export const baseUrl = environment.production ? 'https://mercadofusion.com' : 'http://localhost:5001/api'

export const productUrl = baseUrl + '/Product'

export const productcategoryUrl = baseUrl + '/ProductsCategory'

export const userUrl = baseUrl + '/User'





