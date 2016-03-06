using Microsoft.VisualStudio.TestTools.UnitTesting;
using MugPeru.Sales.Model;
using MugPeru.Sales.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Repository.SqlServer.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Product newProduct = new Product()
            {
                Name = "XBox",
                UnitPrice = 1500,
                UnitsInStock = 16
            };

            ProductRepository repository = new ProductRepository();
            var result = repository.Create(newProduct);

            Assert.AreNotEqual<int>(0, result.Id);
        }

        [TestMethod()]
        public void GetListTest()
        {
            ProductFilter pf = new ProductFilter()
            {
                Name = "XBox",
            };
            Pagination p = new Pagination()
            {
                Page = 1,
                Records = 10
            };
        
            ProductRepository repository = new ProductRepository();
            var result = repository.GetList(pf, ProductListFilterType.ByName, p);

            Assert.IsTrue(result.Count() > 0);
        }
    }
}