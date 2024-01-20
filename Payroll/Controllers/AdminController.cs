using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Payroll.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Payroll.Controllers;
[Log]
public class AdminController : Controller
{
    private readonly ApplicationDbcontext _database;

   public AdminController(ApplicationDbcontext database)
   {
    _database=_database;
   }
    public IActionResult ViewFeedback()
    {
        List<Feedback> feedbacks = EmpRegister.FeedBackClass();
        return View(feedbacks);
    }

    [HttpGet]
    public IActionResult EmployeeDetails()
    {
        List<CreateEmpAccount> EmpDetails = EmpRegister.EmployeeRegister();
        return View(EmpDetails);
    }
    [HttpPost]
    public IActionResult EmployeeDetails(int id)
    {
        Console.WriteLine(id);    
        CreateEmpAccount employee=EmpRegister.searchEmployee(id);
        return RedirectToAction("EmpUpdate",employee);
    }

    [HttpGet]
    public IActionResult EmpUpdate(CreateEmpAccount details)
    {
        return View(details);
    }
    [HttpPost]
    public IActionResult EmpUpdat(CreateEmpAccount details)
    {
        int count = EmpRegister.UpdateEmployee(details);
        if(count==1)
        {
            ViewBag.Message="Employee Details Updated Successfully";
            return View("EmpUpdate");
        }
        else
        {   
            ViewBag.Message="Employee Details Updation Failed";
            return View("EmpUpdate");
        }
    }

    
    public IActionResult AdminHome()
    {
        int count = EmpRegister.idCount();
        ViewBag.Count=count;

        AdminLogin admin = new AdminLogin();
        admin.UserName=HttpContext.Session.GetString("UserName");
        return View(admin); 

        
    } 

    

    [HttpGet]
    public IActionResult SalaryReportSearch()
    {
        return View();
    }   
    [HttpPost]
    public IActionResult SalaryReportSearch(CreateEmpAccount ID)
    {
        System.Console.WriteLine(ID.EmpID);

        int count = EmpRegister.idCount();
        if(ID.EmpID > count)
        {
         ViewBag.Message="Enteres ID in not Valid";
            return View();
        }
        else
        {
            CreateEmpAccount employee=EmpRegister.searchEmployee(ID.EmpID);
            return View("SalaryReportResult",employee);  
        }
    }
    

    public IActionResult SalaryReport()
    {
        return View();
    }

    public IActionResult SalaryCategory()
    {
        return View();
    }
    [HttpGet]

    public IActionResult AdminLogin()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult AdminLogin(AdminLogin admin)
    {
        int check=EmpRegister.adminLogin(admin);
        if(check==1)
        {
            CookieOptions cookieOptions =new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Logintime",DateTime.Now.ToString(),cookieOptions);
            TempData["Cookies"]="Last Login : "+Request.Cookies["Logintime"];
            HttpContext.Session.SetString("UserName",admin.UserName);
            return RedirectToAction("AdminHome");
        }
        else
        {
            ViewBag.message="*Invalid Username or Password";
            return View("AdminLogin");
        }
    }

    [HttpGet]
    public IActionResult AddAdmin()
    {
        return View();
    }  

    [HttpPost]
    public IActionResult AddAdmin(CreateAdminAcc admin)
    {
        System.Console.WriteLine("add admin entered");
        int check = EmpRegister.AddAdmin(admin);
        if(check==1)
        {
            ViewBag.message="*UserName already Exist";
            return View("AddAdmin");
        }
        else if(check == 2)
        {
            ViewBag.message="*Check the Password, Dosen't match";
            return View("AddAdmin");
        }
        else if(check == 3)
        {
            ViewBag.message="*Email already exist";
            return View("AddAdmin");
        }
        else
        {
            ViewBag.message="*Admin account added sucessfully";
            return View("AddAdmin");
        }
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        System.Console.WriteLine(id);
        int check = EmpRegister.DeleteEmployee(id);
        if(check==1)
        {
            ViewBag.Message="Employee Deleted Successfully";
            return RedirectToAction("EmployeeDetails");
        }
        else
        {
            ViewBag.Message="Employee Deletion Failed";
            return RedirectToAction("EmployeeDetails");
        }
    }
    [HttpGet]
     public IActionResult CreateEmpAccount()
    {
        System.Console.WriteLine("Hi guys...");
        return View();
    }

    [HttpPost]
    public IActionResult CreateEmpAccount(CreateEmpAccount userAccount)
    {
        int check=EmpRegister.signUpValidation(userAccount);
        Console.WriteLine(check);
        if(check == 1)
        {

            return View("EmpAccountCreated");
        }
        else if(check == 2)
        {
            ViewBag.message="*Check password";
            return View("CreateEmpAccount");
        }
        else if ( check == 3)
        {
            
            ViewBag.message="*Check username";
            return View("CreateEmpAccount");
        }
        else if ( check == 4)
        {
            ViewBag.message="*You already used this email";
            return View("CreateEmpAccount");
        }
        else
        {
            return View();

        }
    }
    
    public IActionResult GenerateSalary()
    {
        return View();
    }

    public IActionResult SingleTrans()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SalaryClass()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SalaryClass(CreateSalaryClass salary)
    {
        System.Console.WriteLine(salary.ClassName+ "########"+salary.BasicPay+"0000000"+salary.MedicalAlowance);
       int result = EmpRegister.addsalaryClass(salary);
       
       if (result == 1)
       {
           ViewBag.message="*Salary Class Added Successfully";
           return View("SalaryClass");
       }
       if (result == 3)
       {
              ViewBag.message="*className is Null";
              return View("SalaryClass");
       }
       else
       {
           ViewBag.message="*Salary Class Addition Failed";
           return View("SalaryClass");
       }
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}