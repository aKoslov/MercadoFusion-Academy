using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.WebAPI.Models;

namespace Tienda.WebAPI.Models
{
    public class ProductListResponse
    {
        public int productCount { get; set; }
        public List<Dto.Product> productsList { get; set; }
    }
}
