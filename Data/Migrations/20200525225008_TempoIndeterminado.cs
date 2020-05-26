using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TempoIndeterminado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MultaAtraso",
                table: "FinanceiroParcela",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)");

            migrationBuilder.AddColumn<bool>(
                name: "TempoIndeterminado",
                table: "Financeiro",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoIndeterminado",
                table: "Financeiro");

            migrationBuilder.AlterColumn<decimal>(
                name: "MultaAtraso",
                table: "FinanceiroParcela",
                type: "decimal(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);
        }
    }
}
