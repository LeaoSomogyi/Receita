using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<IList<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<int> AddAsync(Usuario usuario);
        Task<int> UpdateAsync(Usuario usuario);
        Task<int> RemoveAsync(int id);
    }
}
