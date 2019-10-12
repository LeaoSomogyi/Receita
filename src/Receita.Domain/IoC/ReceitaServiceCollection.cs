using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Services.Categorias;
using Receita.Domain.Services.Grupos;
using Receita.Domain.Services.Receitas;
using Receita.Domain.Services.Status;
using Receita.Domain.Services.Usuarios;

namespace Receita.Domain.IoC
{
    public static class ReceitaServiceCollection
    {
        public static void AddService(this IServiceCollection services)
        {
            #region "  Contextos  "

            services.AddScoped<DbContext, ReceitaContext>();

            #endregion

            #region "  Repositórios  "

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region "  Serviços  "

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion
        }
    }
}
