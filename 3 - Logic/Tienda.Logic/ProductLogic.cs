using System.Collections.Generic;
using Tienda.DapperDA;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class ProductLogic: IProductLogic
    {
        public DapperDataAccess dataAccess { get; }

        public ProductLogic()
        {
            this.dataAccess = new DapperDataAccess();
        }

        public ProductLogic(string connString)
        {
            this.dataAccess = new DapperDataAccess(connString);
        }
        
        public long CreateProduct(ProductForInsert product)
        {
            return this.dataAccess.CreateProduct(product);
        }
        
        public ProductList GetProductsPaginated(int index, int fetch, string order)
        {
            return this.dataAccess.GetProductsPaginated(index, fetch, order);
        }
        public ProductList GetProductsFiltered(ProductFilters filters, int index, int fetch)
        {
            var filtersDynamic = new Dapper.DynamicParameters();
            if (filters.Category != 0 )
                filtersDynamic.Add("category", filters.Category);
            else 
                filtersDynamic.Add("category", "%");
            filtersDynamic.Add("pricemin", filters.PriceMin);
            filtersDynamic.Add("pricemax", filters.PriceMax);
            if (filters.Status != -1)
                filtersDynamic.Add("status", filters.Status);
            else
                filtersDynamic.Add("status", "%");
            return this.dataAccess.GetProductsFiltered(filtersDynamic, index, fetch);
        }
        public int DeleteProduct(int id)
        {
            return dataAccess.DeleteProduct(id);
        }


        public bool UpdateProduct(Product newProductData, int id)
        {
            //newProductData.AddedDate = ListProducts().Find(p => p.ProductID == newProductData.ProductID).AddedDate;
            return dataAccess.UpdateProduct(newProductData, id);
        }

        public Product GetProductByID(int id)
        {
            return dataAccess.GetProductByID(id);
        }

        public ProductList GetProductByName(string name)
        { 
            return dataAccess.GetProductByName(name);
        }

        
    }
}