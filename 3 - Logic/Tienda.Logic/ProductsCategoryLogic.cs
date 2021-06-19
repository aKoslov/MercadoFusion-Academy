using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dapper;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class ProductsCategoryLogic : IProductsCategoryLogic
    {
        public DapperDataAccess dataAccess { get; }

        public ProductsCategoryLogic()
        {
            this.dataAccess = new DapperDataAccess();
        }
        public List<ProductsCategory> ListProductsCategories()
        {
            return dataAccess.ListProductsCategories();
        }

        public void CreateProductsCategory(string description)
        {
            dataAccess.CreateProductsCategory(description);
        }

        public bool DeleteProductsCategory(int id)
        {
            return dataAccess.DeleteProductsCategory(id);
        }

        public void UpdateProductsCategory(ProductsCategory newProductsCategoryData)
        {
            dataAccess.UpdateProductsCategory(newProductsCategoryData);
        }
    }
}
