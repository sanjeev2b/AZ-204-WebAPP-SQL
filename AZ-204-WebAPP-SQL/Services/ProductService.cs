using AZ_204_WebAPP_SQL.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace AZ_204_WebAPP_SQL.Services
{
    public class ProductService(IConfiguration configuration) : IProductService
    {
        private readonly IConfiguration _configuration = configuration;

        private SqlConnection GetConnection()
        {

            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public async Task<List<Product>> GetProducts()
        {
            string functionUrl = "https://sanazurefuncapp.azurewebsites.net/api/GetProducts?code=WjWv1h9YT9dz_qLotkObt0HXZZO_46VeFPG3jmbW0lNcAzFujNhZWw==";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responese = await client.GetAsync(functionUrl);
                string content = await responese.Content.ReadAsStringAsync(); ;

                return JsonSerializer.Deserialize<List<Product>>(content);
            }
        }

    }
}
