using System;
using System.Collections.Generic;

namespace PPM.DAL.Models;

public partial class Employee
{
	public int EmployeeId { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string EmailId { get; set; } = null!;

	public string MobileNumber { get; set; } = null!;

	public string Address { get; set; } = null!;

	public int RoleId { get; set; }

	public string Password { get; set; } = null!;

	public virtual Role Role { get; set; } = null!;

	public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
