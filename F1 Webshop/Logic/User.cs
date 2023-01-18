using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int TotalPoints { get; private set; }

        private readonly IUserDAL _user;
        public User(IUserDAL user)
        {
            _user = user;
        }
        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public bool CheckLogin(string Email, string Password )
        {
            if(Password == _user.GetPassword(Email))
            {
                return true;
            }
            return false;
        }
        public int GetUserId(string Email)
        {
            return _user.GetUserId(Email);
        }

    }
}
