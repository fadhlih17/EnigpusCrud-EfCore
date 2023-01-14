using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnigpusCrudEfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "magazine",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVarchar (12)", nullable: false),
                    title = table.Column<string>(type: "NVarchar (50)", nullable: false),
                    publishperiod = table.Column<string>(name: "publish_period", type: "nvarchar(max)", nullable: false),
                    yearperiod = table.Column<int>(name: "year_period", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magazine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "novel",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVarchar(12)", nullable: false),
                    name = table.Column<string>(type: "NVarchar (50)", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publishyear = table.Column<int>(name: "publish_year", type: "int", nullable: false),
                    writer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_novel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_magazine_title",
                table: "magazine",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_novel_name",
                table: "novel",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "magazine");

            migrationBuilder.DropTable(
                name: "novel");
        }
    }
}
