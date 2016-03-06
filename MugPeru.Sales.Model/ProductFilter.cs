using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Model
{
    public class ProductFilter : EntityBase
    {
        public decimal UnitPriceIni { get; set; }
        public decimal UnitPriceEnd { get; set; }
    }
}
