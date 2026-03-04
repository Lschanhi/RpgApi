using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoArma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ARMAS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ARMAS", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "TB_ARMAS",
                columns: new[] { "id", "dano", "nome" },
                values: new object[,]
                {
                    { 1, 10, "Anduril" },
                    { 2, 50, "Sting" },
                    { 3, 150, "Glamdring" },
                    { 4, 200, "Orcrist" },
                    { 5, 80, "Grond" },
                    { 6, 99, "Axe of Gimli" },
                    { 7, 60, "Espada Dos Nazgul" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ARMAS");
        }
    }
}
