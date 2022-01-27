using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePoint.DAL.Migrations
{
    public partial class colChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrewUserName",
                table: "Incidents");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorUserName",
                table: "Incidents",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "528bc254-b05d-4fc2-8555-2c45521530b5", "AQAAAAEAACcQAAAAECK2S0okgRDrjSQMmxTp4fNAeAo8aegjqeR40IoUuW8YFZbaIrEIUr9NAfWJOc9p5w==", "df753719-4503-4f2b-a54d-17ebfa4c1add" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupervisorUserName",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrewUserName",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4fb0a94-6c0c-4305-814b-28358661e2f6", "AQAAAAEAACcQAAAAEMnWCFvL1cjVvahBWfKdtIZapTeYMoAh9fOqeHCpyHpzk8g8UPmcOIrGbfB/JtzNBw==", "1062f659-22d2-41bc-baee-ab5856dceff5" });
        }
    }
}
