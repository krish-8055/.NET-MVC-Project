using System.ComponentModel.DataAnnotations;
namespace Payroll.Models
{
    public class CreateEmpAccount
    {
    [Key]
    public int EmpID{get;set;}
    public string? Name{get;set;} 
    public string? Address{get;set;} 
    public string? Gender{get;set;} 
    public string? City{get;set;} 
    public string? Pincode{get;set;}
    public string? Mobile{get;set;}
    public string? Salary{get;set;} 
    public string? Department{get;set;} 
    public string? BankAccNo{get;set;} 
    public string? Email{get;set;}
    public string? BasicPay{get;set;} 
    public string? Password{get;set;} 
    public string? RePassword{get;set;} 
    }
}