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

        private readonly IProductCollectionDAL _Dal;

        public ProductCollection(IProductCollectionDAL product)
        {
            _Dal = product;
        }

        public Product GetProduct(ProductName productname)
        {
            Product product = _Dal.GetProduct(productname);
            return product;
        }
    }
}
