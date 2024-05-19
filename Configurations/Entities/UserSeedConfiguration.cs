using Microsoft.EntityFrameworkCore;
using LeaveManagementWebApp.Data;
using Microsoft.AspNetCore.Identity;
namespace LeaveManagementWebApp.Configurations.Entities
{
	public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
		{
			var hasher = new PasswordHasher<Employee>();
			builder.HasData(
				new Employee
				{
					Id = "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
					Email = "admin@admin.com",
					NormalizedEmail = "ADMIN@ADMIN.COM",
					UserName = "admin@admin.com",
					NormalizedUserName = "ADMIN@ADMIN.COM",
					FirstName = "System",
					LastName = "Admin",
					PasswordHash = hasher.HashPassword(null, "Admin!2"),
					EmailConfirmed = true
				},
				new Employee
				{
					Id = "0f49e776-a962-4cfd-8351-05ff575fe74e",
					Email = "admin1@admin.com",
					NormalizedEmail = "ADMIN1@ADMIN.COM",
					UserName = "admin1@admin.com",
					NormalizedUserName = "ADMIN1@ADMIN.COM",
					FirstName = "System",
					LastName = "User",
					PasswordHash = hasher.HashPassword(null, "Admin!2"),
					EmailConfirmed = true
				}
			); ;
		}
	}
}