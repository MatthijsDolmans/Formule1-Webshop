using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IorderDAL
    {
        public void MakeOrder(DateTime date,int ProductId,int userid);
        public List<Product> GetOrders(int userid);
        public int GetProductID(string productname);
        public List<int> GetOrderIDS(int userid);
        public void AddOrderToExistingOrder(DateTime date, int ProductId, int orderid, int userid);
    }
}
