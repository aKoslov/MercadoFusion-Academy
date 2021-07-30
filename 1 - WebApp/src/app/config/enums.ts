export enum Display {
    SProducts = "Productos",
    SCategories = "Categorías",
    SOrders = "Órdenes",
    SUsersList = "Clientes"

}

export enum UserTypes {
    Customer = "Customer",
    Staff = "Staff",
    Guest = "Guest"
}

export enum ListOrder {
    TimeDesc = "createddate desc",
    TimeAsc = "createddate asc",
    None = "id asc",
    AlphaAsc = "name asc",
    AlphaDesc = "name desc",
    PriceyFirst = "price desc",
    CheaperFirst = "price asc"
}