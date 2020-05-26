using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class asdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParcela",
                table: "FinanceiroParcela",
                type: "decimal(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Financeiro",
                type: "decimal(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParcela",
                table: "FinanceiroParcela",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Financeiro",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)");
        }
    }
}
