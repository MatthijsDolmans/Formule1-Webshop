using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserDAL
    {
        public string GetPassword(string Email);
        public int GetUserId(string Email);
    }
}
