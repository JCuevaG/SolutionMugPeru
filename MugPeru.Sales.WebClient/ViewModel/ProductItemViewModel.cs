using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MugPeru.Sales.WebClient.ViewModel
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short Stock { get; set; }
    }
}