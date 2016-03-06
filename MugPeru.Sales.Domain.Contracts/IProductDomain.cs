using MugPeru.Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Domain.Contracts
{
    public interface IProductDomain
    {
        Product Create(Product product);

        Product GetItem(ProductFilter filter, ProductItemFilterType itemFilter);

        IEnumerable<Product> GetList(ProductFilter filter, ProductListFilterType listFilter, Pagination pagination);
    }
}
