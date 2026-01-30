using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;
using LearnValuate.Models;

namespace LearnValuate.Controllers;

public class VideoController : Controller
{
    private readonly AppDbContext _context;

    public VideoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int courseId)
    {
        var videos = _context.Videos.Where(v => v.CourseId == courseId).ToList();
        ViewBag.CourseId = courseId;
        return View(videos);
    }
    
    [HttpGet]
    public IActionResult Create(int courseId)
    {
        ViewBag.CourseId = courseId;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Video video)
    {
        _context.Videos.Add(video);
        _context.SaveChanges();
        return RedirectToAction("Index", new { courseId = video.CourseId });
    }

    [HttpPost]
    public IActionResult SubmitFeedback(int videoId, bool isLiked, string comment)
    {
        var feedback = new VideoFeedback
        {
            VideoId = videoId,
            IsLiked = isLiked,
            Comment = comment
        };
        _context.VideoFeedbacks.Add(feedback);
        _context.SaveChanges();
        return Ok("Success");
    }
}
