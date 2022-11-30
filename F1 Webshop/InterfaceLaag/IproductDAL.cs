using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag
{
    public interface IproductDAL
    {
        List<Product> GetProduct(ProductName productname);
    }
}
