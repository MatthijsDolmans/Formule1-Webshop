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
        public DateTime Date { get; set; }
        private readonly IorderDAL _order;
        public Order(IorderDAL order)
        {
            _order = order;
            Date = DateTime.Now;
        }
        public List<Product> GetOrders(int userid)
        {
           return _order.GetOrders(userid);
        }
        public void OrderProduct(List<Product> productValues, IProductDAL Product, int userid)
        {
            Product product = new Product(Product);
            if (CanBeBought(productValues, product))
            {
                foreach (var item in productValues)
                {
                    
                   int productid = _order.GetProductID(item.productName.ToString());
                    _order.MakeOrder(Date, productid,userid);
                    product.UpdateProductStock(item.productName);
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
