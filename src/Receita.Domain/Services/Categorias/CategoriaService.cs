using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Categorias
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(Categoria categoria)
        {
            if (categoria != null)
            {
                return await _repository.AddAsync(categoria);
            }

            return 0;
        }

        public async Task<IList<Categoria>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
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

        public async Task<int> UpdateAsync(Categoria categoria)
        {
            if (categoria != null)
            {
                return await _repository.UpdateAsync(categoria);
            }

            return 0;
        }
    }
}
