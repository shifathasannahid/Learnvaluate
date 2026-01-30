using System.ComponentModel.DataAnnotations;

namespace LearnValuate.Models;

public class Video
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string VideoUrl { get; set; }
    
    public int CourseId { get; set; }
    
    public Course Course { get; set; }
}
