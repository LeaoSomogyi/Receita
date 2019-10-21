using Microsoft.AspNetCore.Mvc.Rendering;
using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients.Interfaces
{
    public interface IUsuarioAdmClient
    {
        Task<IEnumerable<UsuarioAdmViewModel>> GetAllAsync();

        Task<IEnumerable<SelectListItem>> GetAllToViewAsync();
    }
}
