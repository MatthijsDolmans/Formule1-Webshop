using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserCollectionDAL
    {
        public void CreateAccount(string Name, string Email, string Password);

        public List<User> GetUsers();
        public void DeleteUser(int UserId);
    }
}
