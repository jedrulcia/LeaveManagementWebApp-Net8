using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "LeaveAllocations",
                newName: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeID = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "LeaveTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b810c559-fbdd-4de9-90aa-e6d4cd3c227a", "AQAAAAIAAYagAAAAEDndWN/tDsoruaH0bW9Dbs8rxu60F3mIFUrIkEr6/rJatixKKZQcK45H8m2L0gThRA==", "4b923db1-c8b9-4b6b-b6d9-a93c36c4c43f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4916dc3-73e6-4897-ad52-a0ca5cda619d", "AQAAAAIAAYagAAAAENNcfi5bk33zTWcGLsz63ZIgGzIln1TYZQxojJdeN0iKPmwW0bKvJHaOhoQkk01l3w==", "3da0b044-1ed6-41de-bdda-ad55216027de" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeID",
                table: "LeaveRequests",
                column: "LeaveTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LeaveAllocations",
                newName: "EmployeeID");

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
    }
}
