using System.ComponentModel.DataAnnotations;
namespace Payroll.Models
{
    public class GenerateSalary
    {
    [Key]
    public string? UserName{get;set;}
    public string? Email{get;set;} 
    public string? Password{get;set;}
    public string? RePassword{get;set;}
    }
}