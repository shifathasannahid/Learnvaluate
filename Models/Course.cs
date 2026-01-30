using System.ComponentModel.DataAnnotations;

namespace LearnValuate.Models;

public class Course
{
    public int Id { get; set; }
    
    [Required]
    public string TutorName { get; set; }
    
    public string LogoFile { get; set; }
    
    public string Description { get; set; }
}
