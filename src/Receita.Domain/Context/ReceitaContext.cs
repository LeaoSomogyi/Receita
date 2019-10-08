using Microsoft.EntityFrameworkCore;
using Receita.Domain.Model;

namespace Receita.Domain.Context
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options)
        { }


        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Papel> Papeis { get; set; }
        public virtual DbSet<Model.Receita> Receitas { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UsuarioAdm> UsuarioAdms { get; set; }


        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ForSqlServerUseIdentityColumns();
            construtorDeModelos.HasDefaultSchema("Receita");

            ConfiguraCategoria(construtorDeModelos);
            ConfiguraPapel(construtorDeModelos);
            ConfiguraStatus(construtorDeModelos);
            ConfiguraUsuaAdm(construtorDeModelos);
            ConfiguraReceita(construtorDeModelos);
        }

        private void ConfiguraCategoria(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Categoria>(edt =>
            {
                edt.ToTable("tbCategoria");
                edt.HasKey(c => c.IdCategoria).HasName("IdCategoria");
                edt.Property(c => c.IdCategoria).HasColumnName("IdCategoria").ValueGeneratedOnAdd();
                edt.Property(c => c.Titulo).HasColumnName("Titulo").HasMaxLength(50);
            });
        }
        private void ConfiguraPapel(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Papel>(edt =>
            {
                edt.ToTable("tbPapel");
                edt.HasKey(c => c.IdPapel).HasName("IdPapel");
                edt.Property(c => c.IdPapel).HasColumnName("IdPapel").ValueGeneratedOnAdd();
                edt.Property(c => c.Desc_papel).HasColumnName("Desc_Papel").HasMaxLength(50);
            });
        }

        private void ConfiguraStatus(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<Status>(edt =>
            {
                edt.ToTable("TbStatus");
                edt.HasKey(c => c.IdStatus).HasName("IdStatus");
                edt.Property(c => c.IdStatus).HasColumnName("IdStatus").ValueGeneratedOnAdd();
                edt.Property(c => c.Desc_Status).HasColumnName("Desc_Status").HasMaxLength(10);

            });
        }
        private void ConfiguraUsuaAdm(ModelBuilder construtorDeModelo)
        {
            construtorDeModelo.Entity<UsuarioAdm>(edt =>
            {
                edt.ToTable("TbUsuariAdm");
                edt.HasKey(c => c.IdUsuarioAdm).HasName("IdUsuarioAdm");
                edt.Property(c => c.IdUsuarioAdm).HasColumnName("IdUsuarioAdm").ValueGeneratedOnAdd();
                edt.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(20);
                edt.Property(c => c.IdPapel).HasColumnName("IdPapel").HasMaxLength(10);
                edt.Property(c => c.Email).HasColumnName("Email").HasMaxLength(50);
            });
        }
        private void ConfiguraReceita(ModelBuilder construtorDeModelo)
        {

            construtorDeModelo.Entity<Model.Receita>(edt =>
            {
                edt.ToTable("TbReceita");
                edt.HasKey(c => c.idReceita).HasName("IdReceita");
                edt.Property(c => c.idReceita).HasColumnName("idReceita").ValueGeneratedOnAdd();
                edt.Property(c => c.IdUsuario).HasColumnName("IdUsuario").HasMaxLength(20);
                edt.Property(c => c.IdCategoria).HasColumnName("IdCategoria").HasMaxLength(400);
                edt.Property(c => c.Ingredientes).HasColumnName("Ingredientes").HasMaxLength(400);
                edt.Property(c => c.ModoDePreparo).HasColumnName("ModoDePreparo").HasMaxLength(400);
                edt.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(400);
                edt.Property(c => c.Status).HasColumnName("Status").HasMaxLength(10);
                edt.Property(c => c.Tag).HasColumnName("Tag").HasMaxLength(10);
                edt.Property(c => c.TituloReceita).HasColumnName("TituloReceita").HasMaxLength(50);
                edt.Property(c => c.Foto).HasColumnName("Foto").HasMaxLength(50);

            });

        }

    }
}
