using Microsoft.EntityFrameworkCore;
namespace Payroll.Models;

public class ApplicationDbcontext : DbContext
{
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) :base(options)
    {

    }
    public DbSet<CreateSalaryClass> SalaryClass{get;set;}
}