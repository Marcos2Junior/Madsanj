using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class deleteParcela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcelas",
                table: "FinanceiroParcela");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Financeiro",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Financeiro",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Perfil = table.Column<int>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionFull",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Projeto = table.Column<string>(nullable: true),
                    Classe = table.Column<string>(nullable: true),
                    Metodo = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionFull", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionFull_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionFull_UsuarioId",
                table: "ExceptionFull",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionFull");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "Parcelas",
                table: "FinanceiroParcela",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Financeiro",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Financeiro",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
