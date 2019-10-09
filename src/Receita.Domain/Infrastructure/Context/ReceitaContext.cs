using Microsoft.EntityFrameworkCore;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Context
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options)
        { }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Models.Receita> Receitas { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ForSqlServerUseIdentityColumns();
           // construtorDeModelos.HasDefaultSchema("Receita");

            ConfiguraCategoria(construtorDeModelos);
            ConfiguraGrupo(construtorDeModelos);
            ConfiguraStatus(construtorDeModelos);
            ConfiguraUsuaAdm(construtorDeModelos);
            ConfiguraReceita(construtorDeModelos);
        }

        private void ConfiguraCategoria(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Categoria>(edt =>
            {
                edt.ToTable("tbCategoria");
                edt.HasKey(c => c.Id).HasName("Pk_Categoria_Id");
                edt.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                edt.Property(c => c.Titulo).HasColumnName("Titulo").HasMaxLength(50);
            });
        }
        private void ConfiguraGrupo(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Grupo>(edt =>
            {
                edt.ToTable("tbGrupo");
                edt.HasKey(c => c.Id).HasName("Pk_Grupo_Id");
                edt.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                edt.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(50);
            });
        }

        private void ConfiguraStatus(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Status>(edt =>
            {
                edt.ToTable("tbStatus");
                edt.HasKey(c => c.Id).HasName("Pk_Status_Id");
                edt.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                edt.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(10);

            });
        }
        private void ConfiguraUsuaAdm(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Usuario>(edt =>
            {
                edt.ToTable("tbUsuario");
                edt.HasKey(c => c.Id).HasName("Pk_Usuario_Id");
                edt.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                edt.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(20);
                edt.Property(c => c.IdGrupo).HasColumnName("IdGrupo").HasMaxLength(10);
                edt.Property(c => c.Email).HasColumnName("Email").HasMaxLength(50);
            });
        }

        private void ConfiguraReceita(ModelBuilder construtorDeModelo)
        {

            construtorDeModelo.Entity<Models.Receita>(edt =>
            {
                edt.ToTable("tbReceita");
                edt.HasKey(c => c.Id).HasName("Pk_Receita_Id");
                edt.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                edt.Property(c => c.IdUsuario).HasColumnName("IdUsuario").HasMaxLength(20);
                edt.Property(c => c.IdCategoria).HasColumnName("IdCategoria").HasMaxLength(400);
                edt.Property(c => c.Ingredientes).HasColumnName("Ingredientes").HasMaxLength(400);
                edt.Property(c => c.ModoDePreparo).HasColumnName("ModoDePreparo").HasMaxLength(400);
                edt.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(400);
                edt.Property(c => c.Status).HasColumnName("Status").HasMaxLength(10);
                edt.Property(c => c.Tag).HasColumnName("Tag").HasMaxLength(10);
                edt.Property(c => c.Titulo).HasColumnName("TituloReceita").HasMaxLength(50);
                edt.Property(c => c.Foto).HasColumnName("Foto").HasMaxLength(50);
            });
        }
    }
}
