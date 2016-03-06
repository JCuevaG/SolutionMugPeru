using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Model
{
    public enum ProductItemFilterType : byte
    {
        ById,
        ByName
    }

    public enum ProductListFilterType : byte
    {
        ByName,
        ByUnitPriceRange,
        ByDynamic
    }
}
