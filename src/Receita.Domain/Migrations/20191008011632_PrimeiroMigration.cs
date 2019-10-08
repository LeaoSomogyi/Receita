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
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCategoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "tbPapel",
                schema: "Receita",
                columns: table => new
                {
                    IdPapel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desc_Papel = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPapel", x => x.IdPapel);
                });

            migrationBuilder.CreateTable(
                name: "TbReceita",
                schema: "Receita",
                columns: table => new
                {
                    idReceita = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("IdReceita", x => x.idReceita);
                });

            migrationBuilder.CreateTable(
                name: "TbStatus",
                schema: "Receita",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desc_Status = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdStatus", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "TbUsuariAdm",
                schema: "Receita",
                columns: table => new
                {
                    IdUsuarioAdm = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    statusIdStatus = table.Column<int>(nullable: true),
                    IdPapel = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUsuarioAdm", x => x.IdUsuarioAdm);
                    table.ForeignKey(
                        name: "FK_TbUsuariAdm_TbStatus_statusIdStatus",
                        column: x => x.statusIdStatus,
                        principalSchema: "Receita",
                        principalTable: "TbStatus",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuariAdm_statusIdStatus",
                schema: "Receita",
                table: "TbUsuariAdm",
                column: "statusIdStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCategoria",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "tbPapel",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "TbReceita",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "TbUsuariAdm",
                schema: "Receita");

            migrationBuilder.DropTable(
                name: "TbStatus",
                schema: "Receita");
        }
    }
}
