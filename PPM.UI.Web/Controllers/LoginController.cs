using Microsoft.AspNetCore.Mvc;
using PPM.DAL;
using PPM.UI.Web.Models;

namespace PPM.UI.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Home()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult login(EmployeeDto employee)
        {
            EmployeeDal employeeDal = new EmployeeDal();
            if (employeeDal.IsValid(employee.email, employee.password))
            {
                string employeeRole = employeeDal.EmployeeRole(employee.email);
                if (employeeRole == "Admin")
                {
                    ViewBag.employee = employee;
                    return View("/Views/Home/admin.cshtml");
                }
                else if (employeeRole == "Manager")
                {
                    ViewBag.employee = employee;
                    return View("/Views/Home/manager.cshtml");
                }
                else
                {
                    ViewBag.employee = employee;
                    return View("/Views/Home/user.cshtml");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }
    }
}
