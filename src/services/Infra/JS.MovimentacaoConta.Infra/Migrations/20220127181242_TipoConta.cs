using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.MovimentacaoConta.Infra.Migrations
{
    public partial class TipoConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "MovimentacaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoConta",
                table: "MovimentacaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "MovimentacaoFinanceira",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "idConta",
                table: "MovimentacaoFinanceira",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "MovimentacaoFinanceira");

            migrationBuilder.DropColumn(
                name: "TipoConta",
                table: "MovimentacaoFinanceira");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "MovimentacaoFinanceira");

            migrationBuilder.DropColumn(
                name: "idConta",
                table: "MovimentacaoFinanceira");
        }
    }
}
