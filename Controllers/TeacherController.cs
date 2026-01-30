using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;
using System.Linq;

namespace LearnValuate.Controllers;

public class TeacherController : Controller
{
    private readonly AppDbContext _context;

    public TeacherController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var teachers = _context.Users.Where(u => u.Role == "Tutor").ToList();
        return View(teachers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var teachers = _context.Users.Where(u => u.Role == "Tutor").ToList();
        return View(teachers);
    }

    [HttpPost]
    public IActionResult Create(string name, string email)
    {
        if (ModelState.IsValid)
        {
            var teacher = new User
            {
                Username = name,
                Email = email,
                Password = "DefaultPassword123!", // Default password
                Role = "Tutor"
            };

            _context.Users.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        var teachers = _context.Users.Where(u => u.Role == "Tutor").ToList();
        return View(teachers);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var teacher = _context.Users.Find(id);
        if (teacher != null)
        {
            _context.Users.Remove(teacher);
            _context.SaveChanges();
        }
        return RedirectToAction("Create");
    }
}
