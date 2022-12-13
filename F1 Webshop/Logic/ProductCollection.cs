using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using static Logic.Helpers.ProductNameEnum;

namespace Logic
{
    public class ProductCollection
    {
        public List<Product> Products { get; set; }

        private readonly IProductCollectionDAL _product;

        public ProductCollection(IProductCollectionDAL product)
        {
            _product = product;
        }

        public List<Product> GetProduct(ProductName productname)
        {
            List<Product> item = _product.GetProduct(productname);
            return item;
        }
    }
}
