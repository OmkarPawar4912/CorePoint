using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePoint.DAL.Migrations
{
    public partial class RemoveColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Incidents_IncidentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IncidentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_AspNetUsers_EmployeeId",
                table: "Incidents",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_AspNetUsers_EmployeeId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Incidents");

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IncidentId",
                table: "AspNetUsers",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Incidents_IncidentId",
                table: "AspNetUsers",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
