using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Order
    {
        public List<Product> ProductsBought { get; private set; }

        public void BuyProduct(Product product)
        {
            if(product.CanProductBeBought() == true)
            {
               ProductsBought.Add(product);
            }
        }
    }
}
