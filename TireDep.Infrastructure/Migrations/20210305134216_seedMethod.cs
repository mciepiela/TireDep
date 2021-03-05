using Microsoft.EntityFrameworkCore.Migrations;

namespace TireDep.Infrastructure.Migrations
{
    public partial class seedMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "Contacts",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SeasonTires",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Summer" });

            migrationBuilder.InsertData(
                table: "SeasonTires",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Winter" });

            migrationBuilder.InsertData(
                table: "SeasonTires",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "All Season" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeasonTires",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SeasonTires",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SeasonTires",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldNullable: true);
        }
    }
}
