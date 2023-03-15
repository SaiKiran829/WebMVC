using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PPM.DAL.Models;

public partial class ProlificsProjectManagement : DbContext
{
	public ProlificsProjectManagement()
	{
	}

	public ProlificsProjectManagement(DbContextOptions<ProlificsProjectManagement> options)
		: base(options)
	{
	}

	public virtual DbSet<Employee> Employees { get; set; }

	public virtual DbSet<Project> Projects { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseMySql("server=10.11.50.58;port=3306;user=tempuser;password=Admin@1234;database=projectmanagement", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.UseCollation("utf8mb4_0900_ai_ci")
			.HasCharSet("utf8mb4");

		modelBuilder.Entity<Employee>(entity =>
		{
			entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

			entity.ToTable("employees");

			entity.HasIndex(e => e.EmailId, "emailId").IsUnique();

			entity.HasIndex(e => e.RoleId, "roleId");

			entity.Property(e => e.EmployeeId)
				.ValueGeneratedNever()
				.HasColumnName("employeeId");
			entity.Property(e => e.Address)
				.HasMaxLength(200)
				.HasColumnName("address");
			entity.Property(e => e.EmailId)
				.HasMaxLength(150)
				.HasColumnName("emailId");
			entity.Property(e => e.FirstName)
				.HasMaxLength(100)
				.HasColumnName("firstName");
			entity.Property(e => e.LastName)
				.HasMaxLength(100)
				.HasColumnName("lastName");
			entity.Property(e => e.MobileNumber)
				.HasMaxLength(15)
				.HasColumnName("mobileNumber");
			entity.Property(e => e.Password)
				.HasMaxLength(20)
				.HasColumnName("password");
			entity.Property(e => e.RoleId).HasColumnName("roleId");

			entity.HasOne(d => d.Role).WithMany(p => p.Employees)
				.HasForeignKey(d => d.RoleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employees_ibfk_1");
		});

		modelBuilder.Entity<Project>(entity =>
		{
			entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

			entity.ToTable("projects");

			entity.Property(e => e.ProjectId)
				.ValueGeneratedNever()
				.HasColumnName("projectId");
			entity.Property(e => e.EndDate)
				.HasMaxLength(20)
				.HasColumnName("endDate");
			entity.Property(e => e.ProjectName)
				.HasMaxLength(50)
				.HasColumnName("projectName");
			entity.Property(e => e.StartDate)
				.HasMaxLength(20)
				.HasColumnName("startDate");

			entity.HasMany(d => d.Employees).WithMany(p => p.Projects)
				.UsingEntity<Dictionary<string, object>>(
					"Projectswithemployee",
					r => r.HasOne<Employee>().WithMany()
						.HasForeignKey("EmployeeId")
						.HasConstraintName("employee_Id_Fk"),
					l => l.HasOne<Project>().WithMany()
						.HasForeignKey("ProjectId")
						.HasConstraintName("project_Id_Fk"),
					j =>
					{
						j.HasKey("ProjectId", "EmployeeId")
							.HasName("PRIMARY")
							.HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
						j.ToTable("projectswithemployees");
						j.HasIndex(new[] { "EmployeeId" }, "employee_Id_Fk");
					});
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.RoleId).HasName("PRIMARY");

			entity.ToTable("roles");

			entity.Property(e => e.RoleId)
				.ValueGeneratedNever()
				.HasColumnName("roleId");
			entity.Property(e => e.RoleName)
				.HasMaxLength(50)
				.HasColumnName("roleName");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
