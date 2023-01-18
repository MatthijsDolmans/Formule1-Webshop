using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserCollection
    {
        private readonly IUserCollection _Dal;

        public UserCollection(IUserCollection dal)
        {
            _Dal = dal;
        }
        public void CreateAccount(string Name, string Email, string Password)
        {
            _Dal.CreateAccount(Name, Email, Password);
        }
    }
}
