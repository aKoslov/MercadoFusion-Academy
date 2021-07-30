
using System.ComponentModel.DataAnnotations;
using Tienda.Dto;

namespace Tienda.WebAPI.Models
{
    public class ProductBase
    {
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public ProductStatus StatusID { get; set; }
    }
        public class ProductToSend
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }
    }

    public class ProductForList
    {

        public int ProductID { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int CategoryID { get; set; }
        public ProductStatus StatusID { get; set; }
    
        public ProductForList(int ID, string name, string description, decimal price, int categoryID, ProductStatus statusID)
        {
            
            ProductID = ID;
            Name = name;
            Description = description;
            Price = price;
            CategoryID = categoryID;
            StatusID = statusID;
        }

    }
}
