using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Entrada = table.Column<bool>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceiroParcela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinanceiroId = table.Column<int>(nullable: false),
                    Parcelas = table.Column<int>(nullable: false),
                    ValorParcela = table.Column<decimal>(nullable: false),
                    MultaAtraso = table.Column<decimal>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceiroParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceiroParcela_Financeiro_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Financeiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinanceiroParcela_FinanceiroId",
                table: "FinanceiroParcela",
                column: "FinanceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceiroParcela");

            migrationBuilder.DropTable(
                name: "Financeiro");
        }
    }
}
