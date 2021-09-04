using Microsoft.EntityFrameworkCore.Migrations;

namespace GelaBahia.Migrations
{
    public partial class FuncionarioDisponivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Funcionario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Funcionario");
        }
    }
}
