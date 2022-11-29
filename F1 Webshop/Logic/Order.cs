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

        public void OrderProduct(List<Product> product)
        {
            if (CanBeBought(product))
            {
                Console.WriteLine("test");
            }
        }
        public bool CanBeBought(Product product)
        {
            if (product.IsProductInStock() == true & product.ProductNeedsEarlyaccess() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
