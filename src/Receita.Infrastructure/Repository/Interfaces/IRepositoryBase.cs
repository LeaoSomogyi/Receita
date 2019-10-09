using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Receita.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(params object[] key);
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
        void Dispose();
    }
}