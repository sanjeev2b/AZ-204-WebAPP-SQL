using AZ_204_WebAPP_SQL.Models;

namespace AZ_204_WebAPP_SQL.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}