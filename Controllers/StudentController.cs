using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;
using System.Linq;

namespace LearnValuate.Controllers;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var students = _context.Users.Where(u => u.Role == "Student").ToList();
        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var students = _context.Users.Where(u => u.Role == "Student").ToList();
        return View(students);
    }

    [HttpPost]
    public IActionResult Create(string name, string email)
    {
        if (ModelState.IsValid)
        {
            var student = new User
            {
                Username = name,
                Email = email,
                Password = "DefaultPassword123!", // Default password
                Role = "Student"
            };

            _context.Users.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Create"); // Stay on the same page to show updated list
        }
        var students = _context.Users.Where(u => u.Role == "Student").ToList();
        return View(students);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var student = _context.Users.Find(id);
        if (student != null)
        {
            _context.Users.Remove(student);
            _context.SaveChanges();
        }
        return RedirectToAction("Create"); // Redirect back to Create page
    }
}
