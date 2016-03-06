using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugPeru.Sales.Domain.Contracts;
using MugPeru.Sales.Repository.SqlServer;
using System.Transactions;
using MugPeru.Sales.Domain.Exceptions;
using MugPeru.Sales.Model;
using MugPeru.Sales.Repository.Contracts;

namespace MugPeru.Sales.Domain
{
    public class ProductDomain : IProductDomain
    {
        private IProductRepository productRepository = null;

        public ProductDomain()
        {
            productRepository = new ProductRepository();
        }
        public Product Create(Product product)
        {
            ProductFilter productFilter = new ProductFilter() { Name = product.Name };
            
            using (var txt = new TransactionScope(TransactionScopeOption.Required))
            {
                var productFound = productRepository.GetItem(productFilter, ProductItemFilterType.ByName);
                if (productFound != null)
                {
                    throw new ProductNameFoundExceptions();
                }

                product = productRepository.Create(product);
                txt.Complete();
            }
            return product;
        }

        public Product GetItem(ProductFilter filter, ProductItemFilterType itemFilter)
        {
            var productFound = productRepository.GetItem(filter, itemFilter);
            if(productFound != null)
            {
                // buscar otros datos del productos
            }
            return productFound;
        }

        public IEnumerable<Product> GetList(ProductFilter filter, ProductListFilterType listFilter, Pagination pagination)
        {
            var productFound = productRepository.GetList(filter, listFilter, pagination);
            return productFound;
        }
    }
}
