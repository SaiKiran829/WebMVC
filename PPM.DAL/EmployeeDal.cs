using PPM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PPM.DAL
{
	public class EmployeeDal
	{
		public Boolean IsValid(string email, string password)
		{
			using (ProlificsProjectManagement context = new ProlificsProjectManagement())
			{
				foreach (Employee employee in context.Employees)
				{
					if (employee.EmailId == email && employee.Password == password)
					{
						return true;
					}
				}
				return false;
			}
		}

		public List<Employee> Employees()
		{
			using(ProlificsProjectManagement context = new ProlificsProjectManagement())
			{
				return context.Employees.Include(x => x.Role).ToList();
			}
		}

		public string EmployeeRole(string email)
		{
			using (ProlificsProjectManagement context = new ProlificsProjectManagement())
			{
				var employee = context.Employees.Include(x => x.Role).Where(x => x.EmailId == email).First();
				Console.WriteLine(employee);
				if (employee.Role.RoleName == "Manager")
				{
					return "Manager";
				}
				else if (employee.Role.RoleName == "Admin")
				{
					return "Admin";
				}
				else
				{
					return "User";
				}
			}
		}
	}
}
