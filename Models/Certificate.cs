using System.ComponentModel.DataAnnotations;

namespace LearnValuate.Models;

public class Certificate
{
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public DateTime DateIssued { get; set; }
}
