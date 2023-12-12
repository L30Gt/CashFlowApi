using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LANCAMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLancamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LANCAMENTOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_LANCAMENTOS",
                columns: new[] { "Id", "DataLancamento", "Descricao", "TipoLancamento", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salario de Novembro", 2, 5000.00m },
                    { 2, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluguel de Novembro", 1, 1200.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LANCAMENTOS");
        }
    }
}
