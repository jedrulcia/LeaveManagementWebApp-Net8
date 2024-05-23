using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetCommentToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f49e776-a962-4cfd-8351-05ff575fe74e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cec9e43e-8f09-4670-9ad4-e364d06282f2", "AQAAAAIAAYagAAAAEOo4LxSRs4Izsvt7idot3TxXlPykbQL6XCHwGuZgYvinldeSJdIokQUYFp0qlfnNmg==", "65b94818-db48-4aff-baf1-627fb5ee6336" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2f610c-9ad6-4a05-9450-4737bb8d3ace",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3af6914-2a82-478e-a285-1f4b0ede16ff", "AQAAAAIAAYagAAAAEL3ciLcjyg2WlqsA5qaeZ2IPfA+Ty1eCHN8eENGyQOUT9NPgyuQC2/vf7qiKYq6asg==", "f7e8323f-cd34-4cbd-8bb0-7340d7d3e669" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
