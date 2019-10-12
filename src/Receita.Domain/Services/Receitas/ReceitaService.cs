using Receita.Domain.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Receitas
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _repository;

        public ReceitaService(IReceitaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(Models.Receita receita)
        {
            if (receita != null)
            {
                return await _repository.AddAsync(receita);
            }

            return 0;
        }

        public async Task<IList<Models.Receita>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.Receita> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Models.Receita>> GetPorCategoriaAsync(int id)
        {
            return await _repository.GetPorCategoriaAsync(id);
        }

        public async Task<int> RemoveAsync(int id)
        {
            if (id > 0)
            {
                return await _repository.RemoveAsync(id);
            }

            return 0;
        }

        public async Task<int> UpdateAsync(Models.Receita receita)
        {
            if (receita != null)
            {
                return await _repository.UpdateAsync(receita);
            }

            return 0;
        }
    }
}
