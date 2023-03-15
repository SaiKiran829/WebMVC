using Microsoft.AspNetCore.Mvc;
using PPM.DAL;
using PPM.UI.Web.Models;
using System.Diagnostics;

namespace PPM.UI.Web.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Admin()        
    {
        EmployeeDal employeeDal = new EmployeeDal();
        var employees = employeeDal.Employees();
        return View(employees);
    }
}
