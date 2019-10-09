using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Services.Status
{
    public interface IStatusService
    {
        Task<IList<Models.Status>> GetAllAsync();
        Task<Models.Status> GetByIdAsync(int id);
        Task<int> AddAsync(Models.Status status);
        Task<int> UpdateAsync(Models.Status status);
        Task<int> RemoveAsync(int id);
    }
}
