using MugPeru.Sales.Model;
using MugPeru.Sales.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MugPeru.Sales.WebClient.Assembler
{
    public static class ProductAssambler
    {
        public static List<ProductItemViewModel> ConvertToViewModel(this IEnumerable<Product> source)
        {
            List<ProductItemViewModel> target = new List<ProductItemViewModel>();
            foreach (var item in source)
            {
                target.Add(new ProductItemViewModel
                {
                    Id = item.Id,
                    Name=item.Name,
                    Stock = item.UnitsInStock,
                    UnitPrice = item.UnitPrice

                });
            }

            return target;
        }
    }
}