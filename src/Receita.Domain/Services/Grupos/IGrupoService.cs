using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Grupos
{
    public interface IGrupoService
    {
        Task<IList<Grupo>> GetAllAsync();
        Task<Grupo> GetByIdAsync(int id);
        Task<int> AddAsync(Grupo grupo);
        Task<int> UpdateAsync(Grupo grupo);
        Task<int> RemoveAsync(int id);
    }
}
