using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePoint.DAL.Migrations
{
    public partial class AddColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Incidents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Incidents",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crews",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CrewId",
                table: "AspNetUsers",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Crews_CrewId",
                table: "AspNetUsers",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Crews_CrewId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CrewId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
