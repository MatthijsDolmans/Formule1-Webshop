using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helpers.ProductNameEnum;

namespace Logic.Interfaces
{
    public interface IProductDAL
    {
        public void UpdateProductPrice(ProductName productName, decimal price);
        public void UpdateProductStock(ProductName productName);
    }
}
