using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoLancamentoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LANCAMENTOCATEGORIAS",
                columns: table => new
                {
                    LancamentoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LANCAMENTOCATEGORIAS", x => new { x.LancamentoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_TB_LANCAMENTOCATEGORIAS_TB_CATEGORIAS_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_LANCAMENTOCATEGORIAS_TB_LANCAMENTOS_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "TB_LANCAMENTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_LANCAMENTOCATEGORIAS",
                columns: new[] { "CategoriaId", "LancamentoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 162, 192, 18, 61, 86, 182, 239, 36, 208, 76, 102, 114, 199, 184, 67, 146, 112, 48, 43, 121, 51, 46, 40, 55, 36, 43, 251, 183, 11, 18, 2, 29, 42, 245, 152, 222, 187, 45, 200, 130, 122, 79, 192, 181, 103, 41, 248, 165, 241, 209, 44, 151, 12, 88, 36, 22, 49, 195, 53, 200, 109, 78, 131, 109 }, new byte[] { 200, 219, 106, 62, 34, 55, 251, 188, 29, 175, 196, 127, 134, 242, 141, 123, 94, 179, 237, 17, 64, 2, 214, 1, 7, 166, 226, 244, 187, 246, 243, 137, 174, 19, 151, 44, 1, 137, 68, 164, 138, 238, 241, 116, 98, 20, 77, 136, 97, 191, 218, 93, 105, 61, 32, 200, 173, 146, 204, 251, 215, 28, 156, 212, 17, 118, 170, 223, 162, 221, 255, 58, 38, 234, 3, 194, 210, 168, 80, 89, 72, 148, 150, 189, 118, 104, 27, 178, 65, 235, 115, 159, 173, 231, 7, 102, 238, 189, 25, 135, 167, 92, 8, 46, 140, 187, 57, 172, 31, 151, 211, 90, 179, 8, 113, 35, 92, 227, 230, 224, 68, 182, 247, 99, 126, 159, 92, 122 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_LANCAMENTOCATEGORIAS_CategoriaId",
                table: "TB_LANCAMENTOCATEGORIAS",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LANCAMENTOCATEGORIAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 206, 243, 185, 23, 34, 192, 218, 83, 162, 121, 140, 13, 173, 77, 152, 211, 244, 182, 242, 25, 98, 229, 11, 225, 27, 165, 247, 198, 245, 118, 181, 196, 72, 222, 97, 155, 229, 126, 11, 173, 209, 44, 8, 49, 59, 237, 45, 139, 158, 114, 166, 124, 126, 8, 252, 149, 246, 195, 234, 231, 2, 241, 223, 124 }, new byte[] { 37, 244, 38, 218, 235, 239, 172, 25, 240, 131, 113, 162, 184, 231, 169, 44, 76, 181, 196, 212, 76, 37, 75, 210, 77, 125, 47, 245, 45, 237, 210, 2, 160, 186, 206, 97, 201, 163, 25, 182, 146, 81, 39, 237, 119, 214, 185, 255, 5, 245, 132, 223, 149, 162, 185, 245, 45, 114, 238, 54, 132, 40, 210, 43, 177, 212, 153, 124, 24, 5, 75, 179, 45, 51, 234, 1, 180, 60, 26, 219, 35, 171, 72, 15, 246, 8, 251, 29, 216, 224, 106, 4, 128, 143, 1, 47, 109, 6, 224, 163, 206, 37, 181, 19, 211, 143, 132, 3, 56, 100, 151, 32, 18, 80, 241, 6, 185, 27, 222, 115, 147, 74, 208, 142, 253, 152, 217, 226 } });
        }
    }
}
