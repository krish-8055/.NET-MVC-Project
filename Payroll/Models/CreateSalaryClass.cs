using System.ComponentModel.DataAnnotations;
namespace Payroll.Models
{
    public class CreateSalaryClass
    {
    [Key]
    public string? ClassName{get;set;} 
    public int BasicPay{get;set;}
    public int Salary{get;set;} 
    public int TravelAllowance{get;set;}
    public int MedicalAlowance{get;set;}
    public int InternetAllowance{get;set;}
    }
}