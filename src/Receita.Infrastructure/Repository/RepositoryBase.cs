using Microsoft.EntityFrameworkCore;
using Receita.Domain.Context;
using Receita.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Receita.Infrastructure.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {

        private ReceitaContext _context;

        public RepositoryBase(ReceitaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(params object[] key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var item = await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
            return item;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var item = await _context.Set<T>().ToListAsync();
            return item;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
