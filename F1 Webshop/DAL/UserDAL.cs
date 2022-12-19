using Logic;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helpers.ProductNameEnum;

namespace DAL
{
    public class UserDAL : IUserDAL
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
