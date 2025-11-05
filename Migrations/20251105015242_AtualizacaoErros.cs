using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoErros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Derotas",
                table: "TB_PERSONAGENS",
                newName: "Derrotas");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TB_DISPUTAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Disputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Tx_Narracao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPUTAS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 74, 214, 54, 94, 147, 248, 154, 227, 38, 250, 233, 159, 56, 58, 244, 45, 10, 251, 54, 71, 238, 237, 141, 215, 46, 97, 87, 143, 128, 213, 38, 12, 42, 124, 244, 162, 128, 117, 160, 211, 35, 90, 47, 69, 76, 8, 67, 169, 16, 30, 8, 212, 189, 204, 246, 15, 91, 172, 140, 99, 49, 196, 61, 200 }, new byte[] { 245, 219, 221, 199, 110, 128, 132, 232, 120, 53, 81, 75, 70, 49, 208, 215, 157, 110, 68, 94, 62, 217, 92, 145, 139, 29, 116, 243, 66, 136, 146, 41, 132, 52, 186, 224, 118, 241, 135, 39, 248, 198, 7, 38, 237, 7, 49, 63, 125, 233, 159, 182, 95, 69, 64, 78, 242, 35, 126, 87, 99, 151, 15, 235, 114, 95, 32, 85, 18, 214, 66, 250, 240, 81, 209, 252, 249, 116, 21, 50, 97, 134, 23, 70, 233, 167, 156, 254, 87, 148, 74, 37, 37, 168, 242, 229, 67, 72, 206, 37, 8, 49, 177, 24, 32, 79, 229, 13, 180, 102, 103, 248, 119, 61, 121, 239, 29, 83, 95, 90, 98, 37, 137, 92, 165, 139, 220, 139 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DISPUTAS");

            migrationBuilder.RenameColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                newName: "Derotas");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 214, 207, 56, 175, 212, 13, 13, 129, 198, 208, 19, 204, 142, 13, 21, 249, 68, 130, 253, 19, 175, 31, 185, 182, 182, 167, 39, 246, 214, 4, 139, 226, 238, 82, 192, 129, 190, 176, 50, 200, 109, 138, 222, 221, 195, 128, 147, 162, 68, 52, 126, 7, 148, 103, 114, 144, 60, 121, 135, 220, 39, 230, 170, 191 }, new byte[] { 99, 53, 21, 25, 46, 55, 17, 109, 55, 155, 184, 246, 142, 47, 202, 68, 60, 212, 170, 53, 81, 70, 145, 187, 46, 71, 94, 60, 122, 162, 247, 28, 201, 112, 151, 36, 158, 14, 37, 113, 5, 90, 64, 170, 143, 141, 204, 28, 150, 99, 96, 167, 182, 137, 31, 37, 182, 46, 14, 64, 149, 249, 92, 231, 211, 135, 5, 62, 153, 223, 4, 42, 8, 57, 240, 191, 183, 155, 205, 205, 154, 106, 160, 57, 245, 129, 68, 212, 195, 201, 113, 103, 135, 42, 202, 55, 54, 252, 173, 248, 59, 74, 215, 87, 111, 219, 64, 93, 38, 71, 240, 38, 28, 209, 13, 51, 133, 195, 73, 185, 133, 64, 177, 105, 158, 144, 114, 120 } });
        }
    }
}
