using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // For demonstration purposes, we are using hardcoded credentials.
            // In a real application, you would validate against a database or an authentication service.
            if (username == "admin" && password == "admin123")
            {
                // Authentication successful, redirect to the home page or dashboard
                TempData["username"] = username;
                return RedirectToAction("Index");
            }
            else
            {
                // Authentication failed, show an error message
                ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
                return View();
            }
        }
        public IActionResult Index()
        {
            ViewData["Name"] = "Hemanth";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
