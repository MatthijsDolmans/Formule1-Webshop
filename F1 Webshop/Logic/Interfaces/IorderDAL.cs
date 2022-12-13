using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IorderDAL
    {
        public void MakeOrder(DateTime date,int ProductId);

        public List<Product> GetOrders();
        public int GetProductID(string productname);
    }
}
