using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Grupos
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _repository;

        public GrupoService(IGrupoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(Grupo grupo)
        {
            if (grupo != null)
            {
                return await _repository.AddAsync(grupo);
            }

            return 0;
        }

        public async Task<IList<Grupo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Grupo> GetByIdAsync(int id)
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

        public async Task<int> UpdateAsync(Grupo grupo)
        {
            if (grupo != null)
            {
                return await _repository.UpdateAsync(grupo);
            }

            return 0;
        }
    }
}
