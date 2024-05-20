using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ea75ebd-f102-418c-95b4-262c6ecf3bf7", "AQAAAAIAAYagAAAAEJN7Bv9sYh/JHl/kQRzqWoB+V3x6/llyLnt2PB0nhGyV69RJ/CY5xWM7t8+DTY06AQ==", "913631a3-2db9-4085-8f21-4b461c5e1545" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308c0046-ab1b-4bc1-a954-f978ba909201", "AQAAAAIAAYagAAAAENqp1bP5ySeYq7RfARdwmWgh0wjVmL49Z+NSqNpybhdkDhvrLJ4ajSrJl/l1V0yCDg==", "e4554553-6e7a-472f-86dd-b218dd837c8b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba9e7762-b6f3-4b8d-aeb7-81d3e0942e1b", "AQAAAAIAAYagAAAAEEkW0uO/ByBnOaSZjF3sxOi55JSIJVj+tkD1deKCjBaDBENwT9aoLGh78C2KMrze0A==", "5d0d3e2c-b320-4b09-bc6e-b2fbf40b4c47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b96578fb-9e09-4b61-bc5c-aa47256c33da", "AQAAAAIAAYagAAAAED8tB1DCJB40XZoiHgDrIy03CnK4zlz5I7NB4Jla1uVGY9vxlrQiuFvOaj9UrTReYg==", "fbe2b33c-f944-4314-8b5b-304d3c79de90" });
        }
    }
}
