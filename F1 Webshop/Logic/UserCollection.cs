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
        private readonly IUserCollectionDAL _Dal;

        public UserCollection(IUserCollectionDAL dal)
        {
            _Dal = dal;
        }
        public void CreateAccount(string Name, string Email, string Password)
        {
            _Dal.CreateAccount(Name, Email, Password);
        }
        public List<User> GetUsers()
        {
           return _Dal.GetUsers();
        }
        public void DeleteUser(int UserId)
        {
            _Dal.DeleteUser(UserId);
        }
    }
}
