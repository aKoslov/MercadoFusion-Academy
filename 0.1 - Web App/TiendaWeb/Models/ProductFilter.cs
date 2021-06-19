using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaWeb.Models
{
    public class ProductFilter
    {
        public int? Category { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }


    }
}
