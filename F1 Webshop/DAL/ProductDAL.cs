using Logic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static Logic.Product;
using static System.Formats.Asn1.AsnWriter;

namespace DAL
{
    public class ProductDAL : Iproduct
    {
        private decimal price;
        private string Connectionstring = "Data Source=LAPTOP-CLO5RIMS\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public decimal GetPrice(ProductName productname)
        {
            string Query = "SELECT Price FROM Product where ProductName = 'cap'";

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                using (SqlCommand query = new SqlCommand(Query, conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        price = reader.GetDecimal(0);

                    }
                    return price;
                }

            }
}
    }
}