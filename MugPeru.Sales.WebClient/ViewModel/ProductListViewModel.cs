using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MugPeru.Sales.WebClient.ViewModel
{
    public class ProductListViewModel
    {
        public string ProductFilter { get; set; }
        public IEnumerable<ProductItemViewModel> ProductList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }


    }
}