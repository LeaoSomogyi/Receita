using Microsoft.AspNetCore.Mvc.Rendering;
using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients.Interfaces
{
    public interface ICategoriaClient
    {
        Task<IEnumerable<CategoriaViewModel>> GetCategoriasAsync();

        Task<IEnumerable<SelectListItem>> GetCategoriasToViewAsync();
    }
}
