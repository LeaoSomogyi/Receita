using Microsoft.EntityFrameworkCore.Migrations;

namespace Receita.Domain.Migrations
{
    public partial class SeedAdministrativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbGrupo",
                columns: new[] { "Descricao" },
                values: new[] { "Administrativo" });

            migrationBuilder.InsertData(
                table: "tbGrupo",
                columns: new[] { "Descricao" },
                values: new[] { "Convidado" });

            migrationBuilder.InsertData(
                table: "tbCategoria",
                columns: new[] { "Titulo", "Descricao" },
                values: new[] { "Bolos", "Receitas de Bolo" });

            migrationBuilder.InsertData(
                table: "tbCategoria",
                columns: new[] { "Titulo", "Descricao" },
                values: new[] { "Tortas", "Receitas de Tortas" });

            migrationBuilder.InsertData(
                table: "tbUsuario",
                columns: new[] { "Nome", "Email", "IdGrupo" },
                values: new[] { "Root", "root@receitas.com", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbGrupo",
                keyColumn: "Descricao",
                keyValue: "Administrativo");

            migrationBuilder.DeleteData(
                table: "tbGrupo",
                keyColumn: "Descricao",
                keyValue: "Convidado");

            migrationBuilder.DeleteData(
                table: "tbCategoria",
                keyColumn: "Titulo",
                keyValue: "Tortas");

            migrationBuilder.DeleteData(
                table: "tbCategoria",
                keyColumn: "Titulo",
                keyValue: "Bolos");

            migrationBuilder.DeleteData(
                table: "tbUsuario",
                keyColumn: "Nome",
                keyValue: "Root");
        }
    }
}
