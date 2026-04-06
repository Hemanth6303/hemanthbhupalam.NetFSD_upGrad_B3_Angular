using Microsoft.AspNetCore.Mvc;

[Route("calculator")]
public class CalculatorController : Controller
{
    // ✅ GET → Show Form
    [HttpGet]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }

    // ✅ POST → Perform Addition
    [HttpPost]
    [Route("add")]
    public IActionResult Add(int num1, int num2)
    {
        int result = num1 + num2;

        // Pass result using ViewData
        ViewData["Result"] = result;
        ViewData["Num1"] = num1;
        ViewData["Num2"] = num2;

        return View("Index"); // return same page
    }
}