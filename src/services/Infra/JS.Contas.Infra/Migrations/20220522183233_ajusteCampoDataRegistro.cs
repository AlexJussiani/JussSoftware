using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Contas.Infra.Migrations
{
    public partial class ajusteCampoDataRegistro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataRegistro",
                table: "Contas",
                newName: "DataCadastro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Contas",
                newName: "DataRegistro");
        }
    }
}
