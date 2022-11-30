
using Logic;
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
        public List<Product> GetProduct(ProductName productname)
        {
            List<Product> products = new List<Product>();
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
                        Product product = new Product(Convert.ToDecimal(reader["Price"]), productname, Convert.ToInt32(reader["Stock"]));
                        products.Add(product);

                    }

                }
                return products;
            }
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

        public int UpdateProductStock(ProductName productName, int Stock)
        {
            int newstock = Stock -1;
            string Query = "UPDATE Product SET Stock = @Stock where ProductName = @productname";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = Query;
                comm.Parameters.AddWithValue("@productname", productName);
                comm.Parameters.AddWithValue("@Stock", newstock);
            }
            return newstock;
        }
    }
}

