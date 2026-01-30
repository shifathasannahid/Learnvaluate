using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;

namespace LearnValuate.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public CourseController(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public IActionResult Index()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course course, IFormFile logo_file)
    {
        if (logo_file != null && logo_file.Length > 0)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            
            var fileName = Path.GetFileName(logo_file.FileName);
            var filePath = Path.Combine(uploads, fileName);
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await logo_file.CopyToAsync(stream);
            }
            course.LogoFile = fileName;
        }

        _context.Courses.Add(course);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
