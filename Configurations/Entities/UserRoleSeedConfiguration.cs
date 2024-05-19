using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementWebApp.Configurations.Entities
{
	internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
		{
			builder.HasData(
				new IdentityUserRole<string>
				{
					RoleId = "1e38d667-a851-3ced-7240-04ee464ed63e",
					UserId = "1b2f610c-9ad6-4a05-9450-4737bb8d3ace"
				},
				new IdentityUserRole<string>
				{
					RoleId = "1e38d667-a851-3ced-7241-04ee464ed63e",
					UserId = "0f49e776-a962-4cfd-8351-05ff575fe74e"
				}
			);
		}
	}
}