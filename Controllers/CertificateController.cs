using Microsoft.AspNetCore.Mvc;
using LearnValuate.Data;

namespace LearnValuate.Controllers;

public class CertificateController : Controller
{
    private readonly AppDbContext _context;

    public CertificateController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int userId)
    {
        var cert = _context.Certificates.FirstOrDefault(c => c.Id == userId);
        if (cert == null) return NotFound();

        return View(cert);
    }
}
