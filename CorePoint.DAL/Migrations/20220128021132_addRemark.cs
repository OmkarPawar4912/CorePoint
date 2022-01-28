using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePoint.DAL.Migrations
{
    public partial class addRemark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "IncidentStatuses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8798dad3-b49b-42a2-9fb3-f8ccbe75fea5", "AQAAAAEAACcQAAAAEFFOtnhMZgM+K8IogXzjihzwMcwtBPNocg/KiCk3eiQvHO2CR3u0p6pYjrnJA3l+kQ==", "45931335-21ca-4307-bec6-d3a7df5f60a1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "IncidentStatuses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "251d9489-20ad-4e51-b5a6-aa31d4443230", "AQAAAAEAACcQAAAAEGxjhzt+PdYkEdiHBnL9VsCQStdWNNdBUBq6e3k0H/lDs48kdWwNqN1MDXP0He+lvg==", "a6fe0962-e0b7-4bb0-8f79-3b363bb48b31" });
        }
    }
}
