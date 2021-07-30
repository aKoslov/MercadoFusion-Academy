using Tienda.Dto;
using System.Collections.Generic;

namespace Tienda.Interfaces
{
    public interface IProductLogic
    {
        ProductList GetProductsPaginated(int index, int fetch, string order);

        ProductList GetProductsFiltered(ProductFilters filters, int index, int fetch);

        Product GetProductByID(int id);

        ProductList GetProductByName(string name);

        long CreateProduct(ProductForInsert product);
        
        int DeleteProduct(int id);

        bool UpdateProduct(Product newProductData, int id);
    }

}