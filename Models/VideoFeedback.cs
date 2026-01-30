using System.ComponentModel.DataAnnotations;

namespace LearnValuate.Models;

public class VideoFeedback
{
    public int Id { get; set; }
    
    public int VideoId { get; set; }
    
    public bool IsLiked { get; set; }
    
    public string Comment { get; set; }
    
    public Video Video { get; set; }
}
