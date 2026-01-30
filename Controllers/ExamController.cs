using Microsoft.AspNetCore.Mvc;

namespace LearnValuate.Controllers;

public class ExamController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
