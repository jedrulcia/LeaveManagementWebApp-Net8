using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e38d667-a851-3ced-7240-04ee464ed63e", null, "Administrator", "ADMINISTRATOR" },
                    { "1e38d667-a851-3ced-7241-04ee464ed63e", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f49e776-a962-4cfd-8351-05ff575fe74e", 0, "e668c3c5-09d5-46ea-afae-ff3af2e1c6e4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1@admin.com", false, "System", "User", false, null, "ADMIN1@ADMIN.COM", null, "AQAAAAIAAYagAAAAEGNpGN20MJmlm3lc2kOKYJ4r8p1wzMO1phxwoBB5MwQl/h3P3Y0IFMxpKyVIUMGn7Q==", null, false, "39ec327f-8a6d-48a1-b78e-ba1b3077fd6a", null, false, null },
                    { "1b2f610c-9ad6-4a05-9450-4737bb8d3ace", 0, "8f22f78e-1d5f-4351-a3f2-83c74192f0fc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", false, "System", "Admin", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAIAAYagAAAAEB4PcuceuyJOaHBcRNo+JgiZX3+0O1zJRZZ0gaSUaf5j0gJewMD8eZisWGz6DMHkew==", null, false, "014c945f-0475-41fc-8e66-e7f83025ba53", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1e38d667-a851-3ced-7241-04ee464ed63e", "0f49e776-a962-4cfd-8351-05ff575fe74e" },
                    { "1e38d667-a851-3ced-7240-04ee464ed63e", "1b2f610c-9ad6-4a05-9450-4737bb8d3ace" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e38d667-a851-3ced-7241-04ee464ed63e", "0f49e776-a962-4cfd-8351-05ff575fe74e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e38d667-a851-3ced-7240-04ee464ed63e", "1b2f610c-9ad6-4a05-9450-4737bb8d3ace" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e38d667-a851-3ced-7240-04ee464ed63e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e38d667-a851-3ced-7241-04ee464ed63e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace");
        }
    }
}
