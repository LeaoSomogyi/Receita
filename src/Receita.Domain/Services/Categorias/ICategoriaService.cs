using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Categorias
{
    public interface ICategoriaService
    {
        Task<IList<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task<int> AddAsync(Categoria categoria);
        Task<int> UpdateAsync(Categoria categoria);
        Task<int> RemoveAsync(int id);
    }
}
