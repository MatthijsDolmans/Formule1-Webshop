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
        public void AddOrderToExistingOrder(int ProductId, int orderid);
    }
}
