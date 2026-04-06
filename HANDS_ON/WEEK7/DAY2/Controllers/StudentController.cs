using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        // ✅ GET → Show Form
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        // ✅ POST → Handle Form
        [HttpPost]
        [Route("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            return RedirectToAction("Display", new
            {
                studentName = studentName,
                age = age,
                course = course
            });
        }

        // ✅ Display Data
        [HttpGet]
        [Route("display")]
        public IActionResult Display(string studentName, int age, string course)
        {
            ViewBag.Name = studentName;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}