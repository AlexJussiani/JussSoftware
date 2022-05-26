using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Contas.Infra.Migrations
{
    public partial class AtualizarColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaItems_Contas_PedidoId",
                table: "ContaItems");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "ContaItems",
                newName: "ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_ContaItems_PedidoId",
                table: "ContaItems",
                newName: "IX_ContaItems_ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaItems_Contas_ContaId",
                table: "ContaItems");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "ContaItems",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContaItems_ContaId",
                table: "ContaItems",
                newName: "IX_ContaItems_PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaItems_Contas_PedidoId",
                table: "ContaItems",
                column: "PedidoId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
