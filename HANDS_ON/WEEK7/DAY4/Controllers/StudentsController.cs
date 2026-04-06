using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Show Students
        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.Course)
                .ToList();

            return View(students);
        }

        // ✅ GET: Create
        public IActionResult Create()
        {
            var courses = _context.Courses.ToList();
            Console.WriteLine("Courses Count: " + courses.Count);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }

        // ✅ POST: Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // 🔥 VERY IMPORTANT (reload dropdown)
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View(student);
        }
    }
}