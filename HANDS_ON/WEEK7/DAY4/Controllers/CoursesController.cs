using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        // Show Courses
        public IActionResult Index()
        {
            var courses = _context.Courses
                .Include(c => c.Students)
                .ToList();

            return View(courses);
        }

        // GET: Create Course
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Course
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(course);
        }

    }
}
