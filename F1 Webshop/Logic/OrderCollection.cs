using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class OrderCollection
    {
        private readonly IOrderCollectionDAL _dal;

        public OrderCollection(IOrderCollectionDAL dal)
        {
            _dal = dal;
        }
        public List<int> GetAllOrderIds(int userid)
        {
            return _dal.GetAllOrderIds(userid);
        }

        public List<Order> GetAllOrders(IProductDAL _ProductDal, int userid)
        {
            List<Order> orders = new List<Order>();
            List<int> OrderIds = GetAllOrderIds(userid);
            foreach(int orderid in OrderIds)
            {
                List<Product> products = new List<Product>();
                List<int> ProductIds = _dal.GetProductIDSOfOrder(orderid);
               foreach(int productid in ProductIds)
                {
                  products.Add(_ProductDal.GetProductById(productid));
                }
                Order order = new(products,orderid, _dal.GetDateOfOrder(orderid));
                orders.Add(order);
            }
            return orders;
        }
    }
}
