using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Contas.Infra.Migrations
{
    public partial class deletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
