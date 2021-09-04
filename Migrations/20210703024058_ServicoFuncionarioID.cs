using Microsoft.EntityFrameworkCore.Migrations;

namespace GelaBahia.Migrations
{
    public partial class ServicoFuncionarioID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioID",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servico_ClienteID",
                table: "Servico",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_FuncionarioID",
                table: "Servico",
                column: "FuncionarioID");

            // migrationBuilder.AddForeignKey(
              /*  name: "FK_Servico_Cliente_ClienteID",
                table: "Servico",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioID",
                table: "Servico",
                column: "FuncionarioID",
                principalTable: "Funcionario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade); */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cliente_ClienteID",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioID",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_ClienteID",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_FuncionarioID",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "FuncionarioID",
                table: "Servico");
        }
    }
}
