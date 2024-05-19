using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ba9e7762-b6f3-4b8d-aeb7-81d3e0942e1b", true, "ADMIN1@ADMIN.COM", "AQAAAAIAAYagAAAAEEkW0uO/ByBnOaSZjF3sxOi55JSIJVj+tkD1deKCjBaDBENwT9aoLGh78C2KMrze0A==", "5d0d3e2c-b320-4b09-bc6e-b2fbf40b4c47", "admin1@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b96578fb-9e09-4b61-bc5c-aa47256c33da", true, "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAED8tB1DCJB40XZoiHgDrIy03CnK4zlz5I7NB4Jla1uVGY9vxlrQiuFvOaj9UrTReYg==", "fbe2b33c-f944-4314-8b5b-304d3c79de90", "admin@admin.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e668c3c5-09d5-46ea-afae-ff3af2e1c6e4", false, null, "AQAAAAIAAYagAAAAEGNpGN20MJmlm3lc2kOKYJ4r8p1wzMO1phxwoBB5MwQl/h3P3Y0IFMxpKyVIUMGn7Q==", "39ec327f-8a6d-48a1-b78e-ba1b3077fd6a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8f22f78e-1d5f-4351-a3f2-83c74192f0fc", false, null, "AQAAAAIAAYagAAAAEB4PcuceuyJOaHBcRNo+JgiZX3+0O1zJRZZ0gaSUaf5j0gJewMD8eZisWGz6DMHkew==", "014c945f-0475-41fc-8e66-e7f83025ba53", null });
        }
    }
}
