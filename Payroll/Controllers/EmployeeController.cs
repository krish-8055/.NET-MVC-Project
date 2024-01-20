using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Payroll.Models;

namespace Payroll.Controllers;
[Log]
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

     private readonly ApplicationDbcontext _SalaryDb;
    public EmployeeController(ApplicationDbcontext database)
    {
        _SalaryDb = database;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(EmpSignin emp)
    {
        int result = EmpRegister.EmpSignin(emp);
        System.Console.WriteLine(result);
        if(result == 1)
        {
         CookieOptions cookieOptions =new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Append("Logintime",DateTime.Now.ToString(),cookieOptions);
        TempData["Cookies"]="Last Login : "+Request.Cookies["Logintime"];
         HttpContext.Session.SetString("Email",emp.Email);
         return RedirectToAction("MyAccount","Employee");
         
        }
        else
        {
            ViewBag.Message="Invalid UserName or Password";
            return View();
        }
    }

    public IActionResult EmployeeHome()
    {
        
        if(!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
        {
            return View();
        }
        else
        {
            return RedirectToAction("Login","Home");
        }    
    }
    public IActionResult MyAccount()
    {

        // AdminLogin admin = new AdminLogin();
        // admin.UserName=HttpContext.Session.GetString("UserName");
        // return View(admin);
        EmpSignin emp = new EmpSignin();
        emp.Email=HttpContext.Session.GetString("Email");
        return View(emp);
    }

    
    public IActionResult Feedback(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Feedback(Feedback feedback){
        HttpClient httpClient=new HttpClient();
        string apiUrl="http://localhost:5005/api/Feedback";
        var jsondata = JsonConvert.SerializeObject(feedback);
        var data = new StringContent(jsondata,Encoding.UTF8,"application/json");
        var httpresponse=httpClient.PostAsync(apiUrl,data);
        var result = await httpresponse.Result.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        return RedirectToAction("MyAccount","Employee");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}