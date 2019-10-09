using Receita.Domain.Infrastructure.Context;
using Receita.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Receitas
{
    public class ReceitaService : IReceitaService
    {
        private readonly ReceitaRepository _repository;
        public ReceitaService(ReceitaContext context)
        {
            _repository = new ReceitaRepository(context);
        }

        public async Task<int> AddAsync(Models.Receita receita)
        {
            if(receita != null)
            {
                return await _repository.AddAsync(receita);
            }

            return 0;
        }

        public async Task<IList<Models.Receita>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<Models.Receita> GetByIdAsync(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<int> RemoveAsync(int id)
        {
            if(id > 0)
            {
                return await _repository.RemoveAsync(id);
            }

            return 0;
        }

        public async Task<int> UpdateAsync(Models.Receita receita)
        {
            if(receita != null)
            {
                return await _repository.UpdateAsync(receita);
            }

            return 0;
        }
    }
}
