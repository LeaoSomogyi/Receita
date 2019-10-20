using AutoMapper;
using Receita.API.Models;
using Receita.Domain.Models;
using Model = Receita.Domain.Models;

namespace Receita.API.Mappings
{
    public class ReceitaMapping : Profile
    {
        public ReceitaMapping()
        {
            CreateMap<CategoriaModel, Categoria>();
            CreateMap<GrupoModel, Grupo>();
            CreateMap<ReceitaModel, Model.Receita>();
            CreateMap<StatusModel, Status>();
            CreateMap<UsuarioModel, Usuario>();   
        }
    }
}
