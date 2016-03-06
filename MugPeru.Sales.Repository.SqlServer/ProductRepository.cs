using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugPeru.Sales.Repository.Contracts;
using MugPeru.Sales.Model;
using MCS.ApplicationBlock.SqlServer;
using System.Data;

namespace MugPeru.Sales.Repository.SqlServer
{
    public class ProductRepository : IProductRepository
    {
        private SqlHelper helper;

        public ProductRepository()
        {
            helper = new SqlHelper(@"Data Source = (local); Initial Catalog= MugPeruDB; user=sa; pwd = Pass@word1");
        }

        public Product Create(Product product)
        {
            List<SqlParameterItem> parameters = new List<SqlParameterItem>();
            parameters.Add(new SqlParameterItem("@ProductID", SqlDbType.Int, 0, ParameterDirection.Output));
            parameters.Add(new SqlParameterItem("@ProductName", SqlDbType.VarChar, product.Name));
            parameters.Add(new SqlParameterItem("@UnitPrice", SqlDbType.Money, product.UnitPrice));
            parameters.Add(new SqlParameterItem("@UnitsInStock", SqlDbType.SmallInt, product.UnitsInStock));
            helper.ExecuteNonQuery("uspAddProduct",parameters);
            product.Id = (int)helper.GetParameterOutput("@ProductId");
            return product;

        }

        public Product GetItem(ProductFilter filter, ProductItemFilterType itemFilter)
        {
            Product product = null;
            switch (itemFilter)
            {
                case ProductItemFilterType.ById:
                    {
                        product = GetItemById(filter.Id);
                    }
                    break;
                case ProductItemFilterType.ByName:
                    {
                        product = GetItemByName(filter.Name);
                    }
                    break;
            }
            return product;
        }

        private Product GetItemById(int id)
        {
            Product product = null;
            SqlParameterItem parameter = new SqlParameterItem("@ProductId", SqlDbType.Int, id);
            var reader = helper.ExecuteReader("uspGetProductById", parameter);
            while (reader.Read())
            {
                product = new Product
                {
                    Id = id,
                    Name = reader.GetString(reader.GetOrdinal("ProductName")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"))
                };
            }
            return product;
        }

        private Product GetItemByName(string name)
        {
            Product product = null;
            SqlParameterItem parameter = new SqlParameterItem("@ProductName", SqlDbType.VarChar, name);
            var reader = helper.ExecuteReader("uspGetProductByName", parameter);
            while (reader.Read())
            {
                product = new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ProductId")),
                    Name = name,
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"))
                };
            }
            return product;
        }

        public IEnumerable<Product> GetList(ProductFilter filter, ProductListFilterType listFilter, Pagination pagination)
        {
            IEnumerable<Product> list = null;

            switch (listFilter)
            {
                case ProductListFilterType.ByName:
                    {
                        list = GetListByName(filter.Name, pagination);
                    }
                    break;
                case ProductListFilterType.ByUnitPriceRange:
                    {
                        
                    }
                    break;
            }

            return list;
        }

        private IEnumerable<Product> GetListByName(string productName, Pagination pagination)
        {
            IList<Product> list = new List<Product>();
            List<SqlParameterItem> parameter = new List<SqlParameterItem>();
            parameter.Add(new SqlParameterItem("@ProductName", SqlDbType.VarChar, productName));
            parameter.Add(new SqlParameterItem("@Page", SqlDbType.Int, pagination.Page));
            parameter.Add(new SqlParameterItem("@Records", SqlDbType.Int, pagination.Records));
            parameter.Add(new SqlParameterItem("@TotalRecords", SqlDbType.Int, 0, ParameterDirection.Output));
            var reader = helper.ExecuteReader("uspGetListProductsByName", parameter);
            while (reader.Read())
            {
                list.Add(new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    Name = reader.GetString(reader.GetOrdinal("ProductName")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                    UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"))
                });
            }
            reader.Close();
            pagination.TotalRecords = (int)helper.GetParameterOutput("@TotalRecords");
            return list;

        }

    }
}
