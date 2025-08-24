using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorCredito.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Simulacoes",
                columns: table => new
                {
                    CO_SIMULACAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PRODUTO = table.Column<int>(type: "int", nullable: false),
                    PC_TAXA_JUROS = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: false),
                    VALOR_DESEJADO = table.Column<decimal>(type: "decimal(22,10)", precision: 22, scale: 10, nullable: false),
                    PRAZO = table.Column<short>(type: "smallint", nullable: false),
                    DATA_REFERENCIA = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacoes", x => x.CO_SIMULACAO);
                });

            migrationBuilder.CreateTable(
                name: "RESULTADOS_SIMULACOES",
                columns: table => new
                {
                    CO_SIMULACAO = table.Column<int>(type: "int", nullable: false),
                    CO_RESULTADO_SIMULACAO = table.Column<int>(type: "int", nullable: false),
                    TIPO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESULTADOS_SIMULACOES", x => new { x.CO_SIMULACAO, x.CO_RESULTADO_SIMULACAO });
                    table.ForeignKey(
                        name: "FK_RESULTADOS_SIMULACOES_Simulacoes_CO_SIMULACAO",
                        column: x => x.CO_SIMULACAO,
                        principalTable: "Simulacoes",
                        principalColumn: "CO_SIMULACAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    CO_SIMULACAO = table.Column<int>(type: "int", nullable: false),
                    CO_RESULTADO_SIMULACAO = table.Column<int>(type: "int", nullable: false),
                    NUMERO = table.Column<short>(type: "smallint", nullable: false),
                    VALOR_AMORTIZACAO = table.Column<decimal>(type: "decimal(22,10)", precision: 22, scale: 10, nullable: false),
                    VALOR_JUROS = table.Column<decimal>(type: "decimal(22,10)", precision: 22, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => new { x.CO_SIMULACAO, x.CO_RESULTADO_SIMULACAO, x.NUMERO });
                    table.ForeignKey(
                        name: "FK_Parcelas_RESULTADOS_SIMULACOES_CO_SIMULACAO_CO_RESULTADO_SIMULACAO",
                        columns: x => new { x.CO_SIMULACAO, x.CO_RESULTADO_SIMULACAO },
                        principalTable: "RESULTADOS_SIMULACOES",
                        principalColumns: new[] { "CO_SIMULACAO", "CO_RESULTADO_SIMULACAO" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "RESULTADOS_SIMULACOES");

            migrationBuilder.DropTable(
                name: "Simulacoes");
        }
    }
}
