using System.ComponentModel.DataAnnotations;

namespace LearnValuate.Models;

public class Payment
{
    public int Id { get; set; }
    
    public string Method { get; set; }
    
    public string CardNumber { get; set; }
    
    public string Expiry { get; set; }
    
    public string Cvv { get; set; }
    
    public string Phone { get; set; }
    
    public string TransactionId { get; set; }
    
    public string Email { get; set; }
    
    public DateTime SubmittedAt { get; set; }
    
    public string Course { get; set; }
}
