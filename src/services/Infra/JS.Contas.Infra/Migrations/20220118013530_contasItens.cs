using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Contas.Infra.Migrations
{
    public partial class contasItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItems_Contas_PedidoId",
                table: "PedidoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems");

            migrationBuilder.RenameTable(
                name: "PedidoItems",
                newName: "ContaItems");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "ContaItems",
                newName: "IX_ContaItems_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaItems",
                table: "ContaItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaItems_Contas_PedidoId",
                table: "ContaItems",
                column: "PedidoId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaItems_Contas_PedidoId",
                table: "ContaItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaItems",
                table: "ContaItems");

            migrationBuilder.RenameTable(
                name: "ContaItems",
                newName: "PedidoItems");

            migrationBuilder.RenameIndex(
                name: "IX_ContaItems_PedidoId",
                table: "PedidoItems",
                newName: "IX_PedidoItems_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItems_Contas_PedidoId",
                table: "PedidoItems",
                column: "PedidoId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
