using Microsoft.EntityFrameworkCore.Migrations;

namespace GabsApi.Migrations
{
    public partial class DataInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OtherGabss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gabss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Gabss",
                columns: new[] { "Id", "Age", "Description", "Name" },
                values: new object[] { 1, 29, "Gabs is nice!", "Gabs" });

            migrationBuilder.InsertData(
                table: "OtherGabss",
                columns: new[] { "Id", "Age", "Description", "GabsId", "Name" },
                values: new object[] { 1, 25, "There's a lot of Gabs", 1, "Gabs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OtherGabss",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gabss",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OtherGabss");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gabss");
        }
    }
}
