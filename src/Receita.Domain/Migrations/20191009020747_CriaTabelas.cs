using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Receita.Domain.Migrations
{
    public partial class CriaTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Categoria_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbGrupo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Grupo_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbReceita",
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
                    table.PrimaryKey("Pk_Receita_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Status_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuario",
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
                    table.PrimaryKey("Pk_Usuario_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropTable(
                name: "tbGrupo");

            migrationBuilder.DropTable(
                name: "tbReceita");

            migrationBuilder.DropTable(
                name: "tbStatus");

            migrationBuilder.DropTable(
                name: "tbUsuario");
        }
    }
}
