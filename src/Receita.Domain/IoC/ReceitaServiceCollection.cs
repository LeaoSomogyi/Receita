using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
