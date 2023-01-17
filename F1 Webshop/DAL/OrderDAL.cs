using Logic;
using Logic.Helpers;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helpers.ProductNameEnum;
using static System.Formats.Asn1.AsnWriter;

namespace DAL
{
    public class OrderDAL : IorderDAL, IOrderCollection
    {
        private string Connectionstring = "Data Source=LAPTOP-CLO5RIMS\\SQLEXPRESS;Initial Catalog = Formule 1 webshop; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<int> GetAllOrderIds(int userid)
        {
            string Query = "SELECT OrderId FROM [dbo].[Order] WHERE CustomerId = @CustomerId";
            List<int> OrderIds = new List<int>();
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                comm.Parameters.AddWithValue("@CustomerId", userid);
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderIds.Add(Convert.ToInt32(reader["OrderId"]));
                    }

                    conn.Close();
                    return OrderIds;
                }
            }
        }

        public List<int> GetProductIDSOfOrder(int OrderId)
        {
            List<int> ProductIds = new List<int>();

                string Query = "SELECT ProductID FROM [dbo].[ProductOrder] WHERE OrderId = @OrderId";
                using (SqlConnection conn = new SqlConnection(Connectionstring))
                {
                    SqlCommand comm = new SqlCommand(Query, conn);
                    conn.Open();
                    comm.Parameters.AddWithValue("@OrderId", OrderId);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductIds.Add(Convert.ToInt32(reader["ProductId"]));
                        }
                        conn.Close();
                    }
                }
            return ProductIds;
        }
        public void MakeOrder(DateTime date,int ProductId, int userid)
        {
            string Query = "INSERT INTO [dbo].[Order]([OrderId],[Date],[CustomerId])VALUES(@OrderId,@date,@CustomerId)";
            int orderid = GetNextId();
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();
               
                SqlCommand comm = conn.CreateCommand();
                comm.Parameters.AddWithValue("@CustomerId", userid);
                comm.CommandText = Query;
                comm.Parameters.AddWithValue("@date", date);
                comm.Parameters.AddWithValue("@OrderId", orderid);
                comm.ExecuteNonQuery();
            }
            string Query2 = "INSERT INTO [dbo].[ProductOrder]([OrderId],[ProductID]) VALUES (@OrderId,@ProductId)";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query2;
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                comm.Parameters.AddWithValue("@OrderId", orderid);
                comm.ExecuteNonQuery();
            }
        }
        public void AddOrderToExistingOrder(int ProductId, int orderid)
        {
            string Query2 = "INSERT INTO [dbo].[ProductOrder]([OrderId],[ProductID]) VALUES (@OrderId,@ProductId)";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query2;
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                comm.Parameters.AddWithValue("@OrderId", orderid);
                comm.ExecuteNonQuery();
            }
        }
        private int GetNextId()
        {
            int count = 0;

            string Query = "SELECT OrderId FROM [dbo].[Order]";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader["OrderId"]);
                    }

                    conn.Close();
                }
            }

            return count + 1;
        }
    }
}
