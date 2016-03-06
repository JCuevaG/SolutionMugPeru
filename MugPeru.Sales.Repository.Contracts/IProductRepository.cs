using MugPeru.Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Repository.Contracts
{
    public interface IProductRepository
    {
        Product Create(Product product);

        Product GetItem(ProductFilter filter,ProductItemFilterType itemFilter);

        IEnumerable<Product> GetList(ProductFilter filter,ProductListFilterType listFilter,Pagination pagination);
    }
}
