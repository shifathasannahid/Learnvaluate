using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using System.Linq;

namespace LearnValuate.Controllers;

public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Login", "Auth");
        }

        // Fetch real-time counts from database
        ViewBag.StudentCount = _context.Users.Count(u => u.Role == "Student");
        ViewBag.TutorCount = _context.Users.Count(u => u.Role == "Tutor");
        ViewBag.CourseCount = _context.Courses.Count();
        ViewBag.VideoCount = _context.Videos.Count(); 
        
        // Use Video count or Exam count if you have an Exam table. 
        // Based on previous context, user asked about exams, but I don't see Exam DbSet in AppDbContext read earlier.
        // I will use 0 for exams for now or check if there is an exam table.
        // Checking AppDbContext again...
        // AppDbContext has: Users, Courses, Videos, VideoFeedbacks, Payments, Certificates.
        // No "Exams" DbSet visible in previous reads.
        // Wait, let me double check the file listing or AppDbContext read result.
        // In the previous read of AppDbContext.cs:
        // public DbSet<User> Users { get; set; }
        // public DbSet<Course> Courses { get; set; }
        // public DbSet<Video> Videos { get; set; }
        // public DbSet<VideoFeedback> VideoFeedbacks { get; set; }
        // public DbSet<Payment> Payments { get; set; }
        // public DbSet<Certificate> Certificates { get; set; }
        // No Exams table.
        // The view shows "Exams" count. I will leave it static or set to 0, or count something else if appropriate.
        // The original view had "Exams". I will set it to 0 for now as there is no Exam table yet.
        
        ViewBag.ExamCount = 0; 

        return View();
    }
}
