using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients.Interfaces
{
    public interface IReceitaClient
    {
        Task<IEnumerable<ReceitaViewModel>> GetReceitasAsync();
    }
}
