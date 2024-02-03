using AZ_204_WebAPP_SQL.Models;
using System.Data.SqlClient;

namespace AZ_204_WebAPP_SQL.Services
{
    public class ProductService(IConfiguration configuration) : IProductService
    {
        //private static string db_source = "sanaz204dbserver.database.windows.net";
        //private static string db_user = "sanjeev2b";
        //private static string db_password = "San007eev#1";
        //private static string db_database = "AZ-204-DB";

        private readonly IConfiguration _configuration = configuration;

        private SqlConnection GetConnection()
        {

            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> productList = [];
            string statement = "SELECT PRODUCTID, PRODUCTNAME, Quantity from PRODUCTS";
            conn.Open();
            SqlCommand cmd = new(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    productList.Add(product);
                }
            }
            conn.Close();
            return productList;
        }

    }
}
