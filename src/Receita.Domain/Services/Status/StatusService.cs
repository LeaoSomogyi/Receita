using System.Collections.Generic;
using System.Threading.Tasks;
using Receita.Domain.Infrastructure.Context;
using Receita.Infrastructure.Repositories;

namespace Receita.Domain.Services.Status
{
    public class StatusService : IStatusService
    {
        private readonly StatusRepository _repository;

        public StatusService(ReceitaContext context)
        {
            _repository = new StatusRepository(context);
        }

        public async Task<int> AddAsync(Models.Status status)
        {
            if(status != null)
            {
                return await _repository.AddAsync(status);
            }

            return 0;
        }

        public async Task<IList<Models.Status>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.Status> GetByIdAsync(int id)
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

        public async Task<int> UpdateAsync(Models.Status status)
        {
            if (status != null)
            {
                return await _repository.UpdateAsync(status);
            }

            return 0;
        }
    }
}
