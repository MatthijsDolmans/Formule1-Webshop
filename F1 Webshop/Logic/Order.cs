using Logic.Interfaces;
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

        public void OrderProduct(List<Product> productValues, IProductDAL Product)
        {
            Product product = new Product(Product);
            if (CanBeBought(productValues, product))
            {
                foreach (var item in productValues)
                {
                    product.UpdateProductStock(item.productName,item.Stock);
                }
            }
        }
        public bool CanBeBought(List<Product> productValues,Product product)
        {
            foreach(var item in productValues)
            {
                if (product.IsProductInStock(item.Stock) == true & product.ProductNeedsEarlyaccess() == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
          
        }
    }
}
