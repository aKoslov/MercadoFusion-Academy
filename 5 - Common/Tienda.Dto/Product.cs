using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Tienda.Dto
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductStatus StatusID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
    }
    public class ProductList
    {
        public List<Product> List { get; set; }
        public int Count { get; set; }
        public int maxPrice { get; set; }
        public int minPrice { get; set; }
    }

    [Table("Products")]
    public class ProductForInsert
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }
    }
}
