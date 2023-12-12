using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIAS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_CATEGORIAS",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Salario" },
                    { 2, "Aluguel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CATEGORIAS");
        }
    }
}
