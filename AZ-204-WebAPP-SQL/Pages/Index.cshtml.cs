using AZ_204_WebAPP_SQL.Models;
using AZ_204_WebAPP_SQL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZ_204_WebAPP_SQL.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products = new List<Product>();

        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();

        }
    }
}
