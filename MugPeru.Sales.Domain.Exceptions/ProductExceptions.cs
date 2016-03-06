using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPeru.Sales.Domain.Exceptions
{

    public class BaseException : ApplicationException
    {
        public string ServerName
        {
            get
            {
                return System.Net.Dns.GetHostName();
            }
        }
    }

    public class ProductNameFoundExceptions : BaseException
    {

        public override string Message
        {
            get
            {
                return "El nombre del producto ya existe";
            }
        }
    }
}
