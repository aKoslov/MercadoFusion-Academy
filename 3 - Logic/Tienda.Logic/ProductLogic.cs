using System.Collections.Generic;
using Tienda.Dapper;
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
        
        public int CreateProduct(Product product)
        {
            return this.dataAccess.CreateProduct(product);
        }
        
        public List<Product> GetProductsPaginated(int index, int fetch)
        {
            return this.dataAccess.GetProductsPaginated(index, fetch);
        }
        public List<Product> GetProductsFiltered(string[] filters, int index, int fetch)
        {
            string filtersPost = "";
            if (!filters[0].Equals(""))
            {
                filtersPost = $"Category = { filters[0] }";
            }
            if (!filters[1].Equals(""))
            {
                if (filtersPost == "")
                    filtersPost = $"Price = { filters[1] }";
                else
                    filtersPost += $" AND Price = { filters[1] }";
            }
            if (!filters[2].Equals(""))
            {
                if (filtersPost == "")
                    filtersPost = $"StatusID = { filters[2] }";
                else
                    filtersPost += $" AND StatusID = { filters[2] }";
            }
                return this.dataAccess.GetProductsFiltered(filtersPost, index, fetch);
        }
        public Product DeleteProduct(int id)
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

        public List<Product> GetProductByName(string name)
        { 
            return dataAccess.GetProductByName(name);
        }

        
    }
}