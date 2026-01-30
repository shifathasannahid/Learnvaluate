using LearnValuate.Data;
using LearnValuate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LearnValuate.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Enroll(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessEnrollment(int courseId, string paymentMethod)
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Simulate payment processing
            bool paymentSuccessful = SimulatePayment(paymentMethod);

            if (paymentSuccessful)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    UserId = user.Id,
                    EnrollmentDate = DateTime.UtcNow
                };

                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

                return RedirectToAction("MyCourses");
            }
            else
            {
                // Handle payment failure
                TempData["ErrorMessage"] = "Payment failed. Please try again.";
                return RedirectToAction("Enroll", new { courseId = courseId });
            }
        }

        private bool SimulatePayment(string paymentMethod)
        {
            // In a real application, you would integrate with a payment gateway here.
            // For this simulation, we'll just return true.
            return true;
        }

        public async Task<IActionResult> MyCourses()
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.UserId == user.Id)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrollments);
        }
    }
}
