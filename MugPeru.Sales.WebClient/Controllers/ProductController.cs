using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MugPeru.Sales.Model;
using MugPeru.Sales.Domain.Contracts;
using MugPeru.Sales.Domain;
using MugPeru.Sales.WebClient.ViewModel;
using MugPeru.Sales.WebClient.Assembler;

namespace MugPeru.Sales.WebClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts(string productNameFilter, int currentPage)
        {
            int records = 10;
            IProductDomain productDomain = new ProductDomain();
            ProductFilter productFilter = new ProductFilter()
            {
                Name = productNameFilter
            };
            Pagination pagination = new Pagination() { Page = currentPage, Records = records };
            var productList = productDomain.GetList(productFilter, ProductListFilterType.ByName, pagination);

            // RETORNO EL JSON
            ProductListViewModel viewModel = new ProductListViewModel()
            {
                ProductFilter = productNameFilter,
                CurrentPage = currentPage,
                TotalRecords = pagination.TotalRecords,
                ProductList = productList.ConvertToViewModel()
            };

        }

    }
}