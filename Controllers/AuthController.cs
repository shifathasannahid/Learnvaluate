using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;

namespace LearnValuate.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string username, string email, string password)
    {
        if (ModelState.IsValid)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Username = username, Email = email, Password = hashedPassword };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("role", user.Role ?? "Student");
            if (string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "StudentDashboard");
            }
        }
        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
