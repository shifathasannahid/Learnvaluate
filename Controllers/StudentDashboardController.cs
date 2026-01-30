using LearnValuate.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LearnValuate.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly AppDbContext _context;

        public StudentDashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var email = HttpContext.Session.GetString("email");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var enrollmentCount = await _context.Enrollments.CountAsync(e => e.UserId == user.Id);
            var courseCount = await _context.Courses.CountAsync();
            var videoCount = await _context.Videos.CountAsync(v => v.CourseId > 0);

            ViewBag.EnrollmentCount = enrollmentCount;
            ViewBag.CourseCount = courseCount;
            ViewBag.VideoCount = videoCount;

            return View();
        }
    }
}
