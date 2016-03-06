using Microsoft.VisualStudio.TestTools.UnitTesting;
using MugPeru.Sales.Domain;
using MugPeru.Sales.Domain.Exceptions;
using MugPeru.Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Domain.Tests
{
    [TestClass()]
    public class ProductDomainTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ProductNameFoundExceptions))]
        public void CreateTest()
        {

            Product newProduct = new Product()
            {
                Name = "chiche",
                UnitPrice = 1500,
                UnitsInStock = 16
            };

            ProductDomain domain = new ProductDomain();
            var result = domain.Create(newProduct);

            Assert.AreNotEqual<int>(0, result.Id);
        }
    }
}