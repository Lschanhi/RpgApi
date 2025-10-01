using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 214, 207, 56, 175, 212, 13, 13, 129, 198, 208, 19, 204, 142, 13, 21, 249, 68, 130, 253, 19, 175, 31, 185, 182, 182, 167, 39, 246, 214, 4, 139, 226, 238, 82, 192, 129, 190, 176, 50, 200, 109, 138, 222, 221, 195, 128, 147, 162, 68, 52, 126, 7, 148, 103, 114, 144, 60, 121, 135, 220, 39, 230, 170, 191 }, new byte[] { 99, 53, 21, 25, 46, 55, 17, 109, 55, 155, 184, 246, 142, 47, 202, 68, 60, 212, 170, 53, 81, 70, 145, 187, 46, 71, 94, 60, 122, 162, 247, 28, 201, 112, 151, 36, 158, 14, 37, 113, 5, 90, 64, 170, 143, 141, 204, 28, 150, 99, 96, 167, 182, 137, 31, 37, 182, 46, 14, 64, 149, 249, 92, 231, 211, 135, 5, 62, 153, 223, 4, 42, 8, 57, 240, 191, 183, 155, 205, 205, 154, 106, 160, 57, 245, 129, 68, 212, 195, 201, 113, 103, 135, 42, 202, 55, 54, 252, 173, 248, 59, 74, 215, 87, 111, 219, 64, 93, 38, 71, 240, 38, 28, 209, 13, 51, 133, 195, 73, 185, 133, 64, 177, 105, 158, 144, 114, 120 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 246, 110, 27, 231, 82, 47, 213, 123, 157, 134, 34, 67, 47, 134, 107, 25, 152, 24, 139, 182, 226, 106, 230, 210, 38, 13, 12, 19, 195, 173, 196, 142, 153, 206, 8, 204, 133, 50, 26, 67, 147, 97, 71, 234, 120, 203, 178, 177, 116, 20, 150, 236, 23, 43, 93, 230, 241, 83, 36, 74, 239, 13, 61 }, new byte[] { 120, 167, 74, 81, 125, 80, 240, 73, 173, 194, 7, 233, 216, 61, 192, 192, 251, 92, 241, 85, 64, 28, 200, 69, 115, 66, 99, 61, 180, 60, 128, 32, 205, 204, 254, 162, 190, 220, 134, 252, 228, 27, 224, 113, 9, 17, 22, 165, 167, 99, 214, 41, 172, 8, 195, 97, 15, 127, 25, 194, 153, 128, 31, 237, 141, 8, 250, 45, 239, 249, 20, 158, 50, 87, 132, 189, 162, 107, 205, 238, 25, 8, 41, 54, 78, 21, 169, 3, 144, 130, 26, 97, 195, 135, 147, 94, 200, 216, 192, 53, 157, 116, 94, 17, 211, 17, 88, 32, 164, 178, 195, 40, 133, 31, 99, 24, 41, 114, 0, 132, 33, 33, 121, 183, 148, 55, 201, 162 } });
        }
    }
}
