using Microsoft.EntityFrameworkCore.Migrations;

namespace Receita.Domain.Migrations
{
    public partial class AlterarTabelaFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "tbReceita",
                maxLength: int.MaxValue,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "tbReceita",
                maxLength: 50,
                nullable: true);
        }
    }
}
