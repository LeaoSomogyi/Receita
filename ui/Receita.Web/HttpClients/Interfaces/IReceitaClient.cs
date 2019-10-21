using Receita.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Web.HttpClients.Interfaces
{
    public interface IReceitaClient
    {
        Task<IEnumerable<ReceitaViewModel>> GetReceitasAsync();

        Task<IEnumerable<ReceitaViewModel>> GetPorCategoriaAsync(int id);

        Task<ReceitaViewModel> GetPorIdAsync(int id);

        Task<bool> DeleteAsync(int id);

        Task<bool> SalvarAsync(ReceitaViewModel receita);
    }
}
