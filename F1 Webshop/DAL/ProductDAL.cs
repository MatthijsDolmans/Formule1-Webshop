
using Logic;
using Logic.Helpers;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static Logic.Helpers.ProductNameEnum;
using static Logic.ProductCollection;
using static System.Formats.Asn1.AsnWriter;

namespace DAL
{
    public class ProductDAL : IProductCollectionDAL, IProductDAL
    {
        // timo 
        // 1. Laat de presentatie laag bepalen wat de connectionstring is (zoek eens uit hoe appsettings werken)
        // 2. Maak een aparte class en maak gebruik van environment variabelen
        private string Connectionstring = "Data Source=LAPTOP-CLO5RIMS\\SQLEXPRESS;Initial Catalog = Formule 1 webshop; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Product GetProduct(ProductName productname)
        {
            string Query = "SELECT * FROM Product where ProductName = @productname";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    query.Parameters.AddWithValue("@productname", productname.ToString());
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                         Product product = new Product(Convert.ToInt32(reader["ProductID"]),Convert.ToDecimal(reader["Price"]), productname, Convert.ToInt32(reader["Stock"]));
                        return product;
                    }
                }
                return null;
            }
        }
        public Product GetProductById(int ProductId)
        {
            string Query = "SELECT * FROM [dbo].[Product] WHERE ProductId = @ProductId";
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (ProductNameEnum.ProductName name in Enum.GetValues(typeof(ProductNameEnum.ProductName)))
                        {
                            string productname = Convert.ToString(reader["ProductName"]);
                            if (name.ToString() == productname)
                            {
                                Product product = new(ProductId, Convert.ToDecimal(reader["Price"]), name, Convert.ToInt32(reader["Stock"]));
                                return product;
                            }

                        }
                        conn.Close();
                    }
                }
            }
            return null;
        }
        public void UpdateProductPrice(ProductName productName, decimal price)
        {
            string Query = "UPDATE Product SET Price = @Price where ProductName = @productname";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query;
                comm.Parameters.AddWithValue("@productname", productName.ToString());
                comm.Parameters.AddWithValue("@Price", price);
            }
        }

        public void UpdateProductStock(ProductName productName)
        {
            int newstock;
            string Query = "SELECT Stock FROM Product where ProductName = @productname";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    query.Parameters.AddWithValue("@productname", productName.ToString());
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        newstock = Convert.ToInt32(reader["Stock"]) - 1;

                        string Query2 = "UPDATE Product SET Stock = @Stock where ProductName = @productname";

                        using (SqlConnection conn2 = new SqlConnection(Connectionstring))
                        {
                            conn2.Open();
                            SqlCommand comm = conn2.CreateCommand();
                            comm.CommandText = Query2;
                            comm.Parameters.AddWithValue("@productname", productName.ToString());
                            comm.Parameters.AddWithValue("@Stock", newstock);
                            comm.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}

