using Microsoft.EntityFrameworkCore.Migrations;

namespace GelaBahia.Migrations
{
    public partial class ClienteID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Servico");
        }
    }
}
