using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.MovimentacaoConta.Infra.Migrations
{
    public partial class ajusteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idConta",
                table: "MovimentacaoFinanceira");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idConta",
                table: "MovimentacaoFinanceira",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
