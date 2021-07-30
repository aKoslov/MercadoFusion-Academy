using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.WebAPI.Models
{
    public class ProductFilter
    {
        public int Category { get; set; } 
        public decimal PriceMin { get; set; }
        public decimal  PriceMax { get; set; }
        public int Status { get; set; } = -1;


    }
}
