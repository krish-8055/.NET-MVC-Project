using System.ComponentModel.DataAnnotations;

namespace Payroll.Models;

public class Feedback
{
    
    [Required]
    public string? Name{get; set;}
    [Required]
    public int Emp_ID{get; set;}
    [Required]
    public string? Subject{get; set;}
    [Required]
    public string? Message{get; set;}

}