using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var emps = _context.Employees
                .Include(e => e.Department)
       
                .ToList();

            return View(emps);
        }

        public IActionResult Departments()
        {
            var depts = _context.Departments
                .Include(d => d.Employees)
              
                .ToList();

            return View(depts);
        }
    }
}