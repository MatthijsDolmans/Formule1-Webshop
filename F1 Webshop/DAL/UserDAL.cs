using Logic;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Logic.Helpers.ProductNameEnum;

namespace DAL
{
    public class UserDAL : IUserDAL, IUserCollectionDAL
    {
        private string Connectionstring = "Data Source=LAPTOP-CLO5RIMS\\SQLEXPRESS;Initial Catalog = Formule 1 webshop; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public string GetPassword(string Email)
        {
            string Password = "";
            string Query = "SELECT password FROM Customer where Email = @Email";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    query.Parameters.AddWithValue("@Email", Email);
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        Password = Convert.ToString(reader["password"]);
                      
                    }

                }
                return Password;
            }
        }
        public void CreateAccount(string Name,string Email,string Password)
        {
            string Query = "INSERT INTO [dbo].[Customer]([Name],[Password],[Email])VALUES(@Name,@Password,@Email)";
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query;
                comm.Parameters.AddWithValue("@Name", Name);
                comm.Parameters.AddWithValue("@Email", Email);
                comm.Parameters.AddWithValue("@Password", Password);
                comm.ExecuteNonQuery();
            }
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string Query = "SELECT * FROM Customer";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new(Convert.ToInt32(reader["CustomerId"]), Convert.ToString(reader["Name"]),Convert.ToString(reader["Email"]));
                        users.Add(user);
                    }

                }
                return users;
            }
        }
        public void DeleteUser(int UserId)
        {
            string Query = "DELETE FROM Customer WHERE CustomerId = @UserId";
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query;
                comm.Parameters.AddWithValue("@UserId", UserId);
                comm.ExecuteNonQuery();
            }
            
        }
        public int GetUserId(string Email)
        {
            int userid = 0;
            string Query = "SELECT CustomerId FROM Customer where Email = @Email";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    query.Parameters.AddWithValue("@Email", Email);
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        userid = Convert.ToInt32(reader["CustomerId"]);

                    }

                }
            }
            return userid;
        }
    }
}
