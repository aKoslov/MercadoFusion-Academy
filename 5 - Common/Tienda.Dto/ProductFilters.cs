using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Dto
{
    public class ProductFilters
    {
        public int Category { get; set; }
        public int PriceMax { get; set; }
        public int PriceMin { get; set; }
        public int Status { get; set; }
    }
}
