using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(Usuario usuario)
        {
            if (usuario != null)
            {
                return await _repository.AddAsync(usuario);
            }

            return 0;
        }

        public async Task<IList<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> RemoveAsync(int id)
        {
            if (id > 0)
            {
                return await _repository.RemoveAsync(id);
            }

            return 0;
        }

        public async Task<int> UpdateAsync(Usuario usuario)
        {
            if (usuario != null)
            {
                return await _repository.UpdateAsync(usuario);
            }

            return 0;
        }
    }
}
