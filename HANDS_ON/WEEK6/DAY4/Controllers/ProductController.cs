using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 50000, Category = "Electronics" },
                new Product { Id = 2, Name = "Mobile", Price = 20000, Category = "Electronics" },
                new Product { Id = 3, Name = "Shoes", Price = 3000, Category = "Fashion" }

            };
        }

        // Index → List of products
        public IActionResult Index()
        {
            var products=GetProducts();
            return View(products);  
        }
        //  Details → Single product
        public IActionResult Details(int id)
        {
            var products = GetProducts().FirstOrDefault(p => p.Id == id);
            if (products == null)
            { 
                return View(null);
               
            }
            else
            {
                return View(products);
            }
        }

    }
}
