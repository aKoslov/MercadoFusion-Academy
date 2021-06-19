using System;
using System.Linq;
using System.Collections.Generic;
using Tienda.Dto;
using Tienda.Interfaces;
using Tienda.Dapper;

namespace Persistencia
{
    public class ProductDataAccess 
    {
        private List<Product>  Products { get; }

        public ProductDataAccess(string connString)
        {
            Products = new List<Product>();
            DapperDataAccess dapperDataAcces = new DapperDataAccess(connString);
        }
        public void CreateProduct(Product product)
        {
            if (Products.Any(p => p.ProductID == product.ProductID))
            {
                throw new Exception("Producto duplicado");
            }
            this.Products.Add(product);
        }
        
        public bool DeleteProduct(int id)
        {
            var product = GetProductByID(id);
            return Products.Remove(product);
        }

        public void UpdateProduct(Product newProductData)
        {
            var currentProduct = GetProductByID((int)newProductData.ProductID);

            if (currentProduct == null) throw new Exception("Producto encontrado");

            currentProduct.Name = newProductData.Name;
            currentProduct.Description = newProductData.Description;
            currentProduct.Price = newProductData.Price;
        }

        public List<Product> ListProducts()
        {
            return this.Products.Select(p => new Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
            
    }

        public Product GetProductByID(int id)
        {
            return Products.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Product> GetProductByName(string input)
        {
            // Lista Auxiliar de Resultados

            List<Product> matches = new List<Product>();

            bool match = false;

            // Iteración en busca de Matches

            foreach (var item in Products)
            {
                string name = item.Name.ToLower();
                // System.Console.WriteLine(item.Name.ToLower());

                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Length > name.Length)
                    {
                        match = false;
                        break;
                    }

                    //Búsqueda caracter por caracter de igualdad

                    if (input[i] != name[i])
                    {
                        match = false;
                        // System.Console.WriteLine(match + " dont match");
                        break;
                    }
                    // else
                    // {
                    //    System.Console.WriteLine(input[i] + "  " + match[i]);
                    // }
                    //If matching string completed  
                    if (i <= name.Length)
                    {
                        match = true;
                    }
                }
                if (match) matches.Add(item);
            }
            return matches;
            // this.Products.FindAll(p => p.Name.ToLower() == input)
        }
    }
} 
// var productos = new List<ProductoListDto>();
            // foreach (var p in this.Productos)
            // {
            //     var producto = new ProductoListDto
            //     {
            //         Id = p.Id,
            //         Nombre = p.Nombre,
            //         Descripcion = p.Descripcion,
            //         Precio = p.Precio
            //     };
            //     productos.Add(producto);
            // }
            // return productos;
        