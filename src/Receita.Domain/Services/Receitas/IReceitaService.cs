using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Receitas
{
    public interface IReceitaService
    {
        Task<IList<Models.Receita>> GetAllAsync();
        Task<Models.Receita> GetByIdAsync(int id);
        Task<int> AddAsync(Models.Receita receita);
        Task<int> UpdateAsync(Models.Receita receita);
        Task<int> RemoveAsync(int id);
    }
}
