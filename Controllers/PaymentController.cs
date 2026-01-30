using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;

namespace LearnValuate.Controllers;

public class PaymentController : Controller
{
    private readonly AppDbContext _context;

    public PaymentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(int courseId)
    {
        ViewBag.CourseId = courseId;
        return View();
    }

    [HttpPost]
    public IActionResult Process(Payment payment)
    {
        payment.SubmittedAt = DateTime.Now;
        // In PHP code, course was bound to payment.course.
        // Assuming payment.Course is the CourseId passed as string.
        
        _context.Payments.Add(payment);
        _context.SaveChanges();
        
        return RedirectToAction("Index", "Video", new { courseId = payment.Course });
    }
}
