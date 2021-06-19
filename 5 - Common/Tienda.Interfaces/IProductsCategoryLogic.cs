using System.Collections.Generic;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IProductsCategoryLogic
    {

        List<ProductsCategory> ListProductsCategories();

        void CreateProductsCategory(string description);

        bool DeleteProductsCategory(int id);

        void UpdateProductsCategory(ProductsCategory newProductsCategoryData);
    }
}
