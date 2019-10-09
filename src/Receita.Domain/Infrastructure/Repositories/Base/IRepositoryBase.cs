using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Infrastructure.Repositories.Base
{
    internal interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(int id);
        void Dispose();
    }
}