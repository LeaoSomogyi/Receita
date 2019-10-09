using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Receita.Domain.Migrations
{
    public partial class PrimeiroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Receita");

            migrationBuilder.CreateTable(
                name: "tbCategoria",
                schema: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbCategoria_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbGrupo",
                schema: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbGrupo_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbReceita",
                schema: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(maxLength: 20, nullable: false),
                    IdCategoria = table.Column<int>(maxLength: 400, nullable: false),
                    TituloReceita = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 400, nullable: true),
                    Ingredientes = table.Column<string>(maxLength: 400, nullable: true),
                    ModoDePreparo = table.Column<string>(maxLength: 400, nullable: true),
                    Foto = table.Column<string>(maxLength: 50, nullable: true),
                    Tag = table.Column<string>(maxLength: 10, nullable: true),
                    Status = table.Column<bool>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbReceita_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbStatus",
                schema: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbStatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuario",
                schema: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    IdGrupo = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbUsuario_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCategoria",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "tbGrupo",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "tbReceita",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "tbStatus",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "tbUsuario",
                schema: "Receita");
        }
    }
}
