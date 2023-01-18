using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderCollection
    {
        public List<int> GetProductIDSOfOrder(int OrderId);
        public List<int> GetAllOrderIds(int userid);
        public DateTime GetDateOfOrder(int orderid);
    }
}
