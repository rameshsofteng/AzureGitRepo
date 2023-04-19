using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLApp.Models;
using SQLApp.Services;

namespace SQLApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductService _productsService = new ProductService();
            Products = _productsService.GetProducts();
        }
    }
}