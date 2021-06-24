using Tienda.Dto;
using System.Collections.Generic;

namespace Tienda.Interfaces
{
    public interface IProductLogic
    {
        List<Product> GetProductsPaginated(int index, int fetch);

        List<Product> GetProductsFiltered(string[] filters, int index, int fetch);

        Product GetProductByID(int id);

        List<Product> GetProductByName(string name);

        Product CreateProduct(Product product);

        //List<Product> ListProducts();
        
        Product DeleteProduct(int id);

        bool UpdateProduct(Product newProductData, int id);
    }

}