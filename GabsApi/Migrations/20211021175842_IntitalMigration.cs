using Microsoft.EntityFrameworkCore.Migrations;

namespace GabsApi.Migrations
{
    public partial class IntitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gabss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherGabss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    GabsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherGabss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherGabss_Gabss_GabsId",
                        column: x => x.GabsId,
                        principalTable: "Gabss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherGabss_GabsId",
                table: "OtherGabss",
                column: "GabsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherGabss");

            migrationBuilder.DropTable(
                name: "Gabss");
        }
    }
}
