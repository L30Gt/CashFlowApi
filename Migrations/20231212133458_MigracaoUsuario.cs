using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_LANCAMENTOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_LANCAMENTOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TB_LANCAMENTOS",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: null);

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, new byte[] { 206, 243, 185, 23, 34, 192, 218, 83, 162, 121, 140, 13, 173, 77, 152, 211, 244, 182, 242, 25, 98, 229, 11, 225, 27, 165, 247, 198, 245, 118, 181, 196, 72, 222, 97, 155, 229, 126, 11, 173, 209, 44, 8, 49, 59, 237, 45, 139, 158, 114, 166, 124, 126, 8, 252, 149, 246, 195, 234, 231, 2, 241, 223, 124 }, new byte[] { 37, 244, 38, 218, 235, 239, 172, 25, 240, 131, 113, 162, 184, 231, 169, 44, 76, 181, 196, 212, 76, 37, 75, 210, 77, 125, 47, 245, 45, 237, 210, 2, 160, 186, 206, 97, 201, 163, 25, 182, 146, 81, 39, 237, 119, 214, 185, 255, 5, 245, 132, 223, 149, 162, 185, 245, 45, 114, 238, 54, 132, 40, 210, 43, 177, 212, 153, 124, 24, 5, 75, 179, 45, 51, 234, 1, 180, 60, 26, 219, 35, 171, 72, 15, 246, 8, 251, 29, 216, 224, 106, 4, 128, 143, 1, 47, 109, 6, 224, 163, 206, 37, 181, 19, 211, 143, 132, 3, 56, 100, 151, 32, 18, 80, 241, 6, 185, 27, 222, 115, 147, 74, 208, 142, 253, 152, 217, 226 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_LANCAMENTOS_UsuarioId",
                table: "TB_LANCAMENTOS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_LANCAMENTOS_TB_USUARIOS_UsuarioId",
                table: "TB_LANCAMENTOS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_LANCAMENTOS_TB_USUARIOS_UsuarioId",
                table: "TB_LANCAMENTOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_LANCAMENTOS_UsuarioId",
                table: "TB_LANCAMENTOS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_LANCAMENTOS");
        }
    }
}
