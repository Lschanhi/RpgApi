using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 246, 110, 27, 231, 82, 47, 213, 123, 157, 134, 34, 67, 47, 134, 107, 25, 152, 24, 139, 182, 226, 106, 230, 210, 38, 13, 12, 19, 195, 173, 196, 142, 153, 206, 8, 204, 133, 50, 26, 67, 147, 97, 71, 234, 120, 203, 178, 177, 116, 20, 150, 236, 23, 43, 93, 230, 241, 83, 36, 74, 239, 13, 61 }, new byte[] { 120, 167, 74, 81, 125, 80, 240, 73, 173, 194, 7, 233, 216, 61, 192, 192, 251, 92, 241, 85, 64, 28, 200, 69, 115, 66, 99, 61, 180, 60, 128, 32, 205, 204, 254, 162, 190, 220, 134, 252, 228, 27, 224, 113, 9, 17, 22, 165, 167, 99, 214, 41, 172, 8, 195, 97, 15, 127, 25, 194, 153, 128, 31, 237, 141, 8, 250, 45, 239, 249, 20, 158, 50, 87, 132, 189, 162, 107, 205, 238, 25, 8, 41, 54, 78, 21, 169, 3, 144, 130, 26, 97, 195, 135, 147, 94, 200, 216, 192, 53, 157, 116, 94, 17, 211, 17, 88, 32, 164, 178, 195, 40, 133, 31, 99, 24, 41, 114, 0, 132, 33, 33, 121, 183, 148, 55, 201, 162 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 150, 129, 192, 213, 159, 252, 68, 150, 99, 77, 241, 51, 114, 211, 19, 86, 230, 248, 39, 175, 200, 237, 192, 102, 80, 229, 4, 154, 93, 112, 63, 142, 93, 146, 211, 223, 85, 157, 139, 24, 208, 54, 67, 18, 159, 222, 34, 242, 171, 127, 181, 90, 96, 135, 18, 205, 183, 153, 143, 78, 27, 112, 109 }, new byte[] { 161, 112, 200, 221, 200, 45, 238, 135, 232, 55, 73, 67, 0, 142, 183, 14, 178, 232, 29, 9, 182, 61, 165, 31, 176, 87, 14, 114, 41, 42, 163, 27, 204, 72, 229, 7, 23, 206, 13, 49, 147, 243, 209, 46, 236, 2, 92, 235, 47, 42, 165, 129, 204, 162, 167, 31, 109, 168, 197, 116, 73, 4, 152, 97, 240, 245, 227, 175, 151, 56, 44, 203, 102, 199, 24, 144, 194, 240, 209, 131, 254, 252, 134, 76, 68, 205, 37, 246, 253, 155, 236, 40, 214, 10, 23, 5, 4, 144, 14, 18, 73, 177, 154, 243, 113, 42, 249, 187, 71, 108, 59, 198, 242, 190, 135, 234, 43, 192, 222, 112, 145, 116, 141, 175, 221, 150, 82, 130 } });
        }
    }
}
